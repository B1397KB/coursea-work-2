function requireRole(role) {
  return function (req, res, next) {
    // In a real app, `req.user` would be populated by auth middleware after token/session verification.
    const user = req.user;
    if (!user) return res.status(401).json({ error: 'unauthenticated' });
    if (user.role !== role) return res.status(403).json({ error: 'forbidden' });
    return next();
  };
}

module.exports = { requireRole };
