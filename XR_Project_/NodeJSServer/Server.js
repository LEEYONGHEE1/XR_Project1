

const WebSocket = require("ws");

const wss = new WebSocket.server({port:8000}, () => {
    console.log("서버 시작");
    console.log(getKey(7));
});

const userlist = [];

wss.on('connection', function connection(ws) {
    ws.clientID = getKey(8);

    ws.on('message', (data) => {

        const jsondata = JSON.parse(data);
        console.log('받은 데이터 :', jsondata);

        wss.clients.array.forEach((client) => {
            client.send(data);
        });
    });

    userlist.push(ws.clientID);

    ws.send(JSON.stringify({clientID: ws.clientID}));

    console.log('클라이언트 연결 - ID', ws.clientID);
});

wss.on('listening', () => {

    console.log("리스닝..");

})

function getKey(length) {
    let result = '';
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    for(let i = 0; i < length; i++)
    {
        result += characters.charAt(Math.floor(Math.random() * characters.length));

    }

    return result;
}

