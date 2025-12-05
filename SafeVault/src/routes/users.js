const express = require('express');
const router = express.Router();
const { body, validationResult } = require('express-validator');
const { sanitizeInput, sanitizeEmail } = require('../utils/validation');
const db = require('../db');

// POST /users/submit
router.post(
  '/submit',
  // validation rules
  body('username').isLength({ min: 1, max: 100 }).trim(),
  body('email').isEmail().normalizeEmail(),
  async (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json({ errors: errors.array() });
    }

    const rawUsername = req.body.username;
    const rawEmail = req.body.email;

    const username = sanitizeInput(rawUsername);
    const email = sanitizeEmail(rawEmail);

    try {
      // parameterized query prevents SQL injection
      const sql = 'INSERT INTO Users (Username, Email) VALUES (?, ?)';
      await db.query(sql, [username, email]);
      return res.status(201).json({ username, email });
    } catch (err) {
      console.error(err);
      return res.status(500).json({ error: 'internal_error' });
    }
  }
);

// GET /users/:id
router.get('/:id', async (req, res) => {
  const id = Number(req.params.id);
  if (!Number.isInteger(id) || id <= 0) return res.status(400).json({ error: 'invalid_id' });

  try {
    const rows = await db.query('SELECT UserID, Username, Email FROM Users WHERE UserID = ?', [id]);
    const user = rows[0] || null;
    if (!user) return res.status(404).json({ error: 'not_found' });
    // ensure returned fields are safe (already sanitized on insert)
    return res.json({ user });
  } catch (err) {
    console.error(err);
    return res.status(500).json({ error: 'internal_error' });
  }
});

module.exports = router;
