// import dbconfig from './data.json' assert { type: 'JSON' };
const express = require('express');
const app = express();


//DATABASE SETUP
// const { Client } = require('pg')
// const client = new Client({
//   host: 'dpg-cd4t4o1gp3jqpbpgfad0-a.frankfurt-postgres.render.com',
//   port: 5334,
//   user: 'database-user',
//   password: 'secretpassword!!',
// })
//------------

app.get('/healthcheck', (req, res) => {
    res.sendStatus(200);
});

app.get('/', (req, res) => {
    res.send('Argentina campeona Qatar 2022\nNO VALE ANTIMUFA');
});

app.get('/api/responses/:userid', (req, res) => {
    const userid = req.params.userid;
    //database query ->
    const object = [];
    if(!objet) res.status(404).send('can send this as error text');
})

const port = process.env.port || 3000;
app.listen(port, () => console.log(`server listening on ${port}`));
