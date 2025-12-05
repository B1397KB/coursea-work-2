const request = require('supertest');
const app = require('../src/index');
const db = require('../src/db');

jest.mock('../src/db');

describe('Input validation and sanitization', () => {
  beforeEach(() => {
    db.query.mockClear();
  });

  test('prevents XSS in username', async () => {
    db.query.mockResolvedValueOnce([]);
    const res = await request(app)
      .post('/users/submit')
      .send({ username: '<script>alert(1)</script>evil', email: 'test@example.com' });

    expect(res.statusCode).toBe(201);
    expect(res.body.username).not.toContain('<script>');
    // db.query should have been called with parameterized SQL
    expect(db.query).toHaveBeenCalledWith(expect.stringContaining('INSERT INTO Users'), expect.any(Array));
  });

  test('handles SQL injection-like payload safely', async () => {
    const malicious = "' OR 1=1 --";
    db.query.mockResolvedValueOnce([]);
    const res = await request(app)
      .post('/users/submit')
      .send({ username: malicious, email: 'attacker@example.com' });

    expect(res.statusCode).toBe(201);
    // ensure db.query received parameters array (no string concatenation in route)
    expect(db.query).toHaveBeenCalledWith(expect.any(String), expect.arrayContaining([expect.any(String), expect.any(String)]));
  });
});
