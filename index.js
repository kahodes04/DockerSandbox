const express = require('express');
const app = express();

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
app.listen(port, () => console.log('server listening'));
