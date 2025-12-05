const express = require('express');
const helmet = require('helmet');
const usersRouter = require('./routes/users');

const app = express();

app.use(helmet());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.use('/users', usersRouter);

// simple health
app.get('/', (req, res) => res.json({ status: 'ok' }));

if (require.main === module) {
  const port = process.env.PORT || 3000;
  app.listen(port, () => console.log(`SafeVault listening on ${port}`));
}

module.exports = app;
