const { hashPassword, verifyPassword } = require('../src/auth');

describe('Authentication helpers', () => {
  test('hash and verify password', async () => {
    const pass = 'S3cur3P@ssw0rd!';
    const h = await hashPassword(pass);
    const ok = await verifyPassword(pass, h);
    expect(ok).toBe(true);
  });
});
