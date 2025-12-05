const bcrypt = require('bcrypt');
const db = require('./db');

async function hashPassword(plain) {
  const saltRounds = 12;
  return bcrypt.hash(plain, saltRounds);
}

async function verifyPassword(plain, hash) {
  return bcrypt.compare(plain, hash);
}

async function createUser(username, email, password, role = 'user') {
  const passwordHash = await hashPassword(password);
  const sql = 'INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES (?, ?, ?, ?)';
  await db.query(sql, [username, email, passwordHash, role]);
}

module.exports = { hashPassword, verifyPassword, createUser };
