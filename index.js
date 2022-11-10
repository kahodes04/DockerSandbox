const config = require('config');
const express = require('express');
const app = express();

//DATABASE SETUP
var pg = require("pg");
var client = new pg.Client({
  host: config.get('server.host'),
  database: config.get('server.database'),
  user: config.get('server.user'),
  password: config.get('server.password'),
  ssl: true
})
client.connect(err => {
    if (err) {
      console.error('connection error', err.stack)
    } else {
      console.log('connected')
    }
  })
//------------

app.get('/healthcheck', (req, res) => {
    res.sendStatus(200);
});

app.get('/', (req, res) => {
    res.send('Argentina campeona Qatar 2022\nNO VALE ANTIMUFA');
});
app.get('/getdb', (req, res) => {
    console.log(client);

      client
      .query('SELECT * FROM "public"."config" LIMIT 1000;')
      .then(data => res.send(data))
      .catch(e => console.error(e.stack))

});

app.get('/adddb/:word', (req, res) => {
    console.log(client);

      client
      .query(`INSERT INTO "public"."config" results VALUES ${req.params.word}`)
      .then(data => res.send(data))
      .catch(e => console.error(e.stack))

});

app.get('/api/responses/:userid', (req, res) => {
    const userid = req.params.userid;
    //database query ->
    const object = [];
    if(!objet) res.status(404).send('can send this as error text');
})

const port = process.env.port || 3000;
app.listen(port, () => console.log(`server listening on ${port}`));
