const xss = require('xss');

function sanitizeInput(input) {
  if (typeof input !== 'string') return '';
  // basic trim + strip control chars
  let s = input.trim();
  s = s.replace(/[\u0000-\u001f\u007f]/g, '');
  // escape any HTML/script content
  s = xss(s);
  // additional allowlist for username characters (letters, numbers, - _ .)
  s = s.replace(/[^a-zA-Z0-9._-]/g, '');
  return s;
}

function sanitizeEmail(email) {
  if (typeof email !== 'string') return '';
  let e = email.trim();
  e = e.replace(/[\u0000-\u001f\u007f]/g, '');
  e = xss(e);
  return e;
}

module.exports = { sanitizeInput, sanitizeEmail };
