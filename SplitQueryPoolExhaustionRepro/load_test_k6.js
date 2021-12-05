import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '30s', target: 500 }, // 30sec ramp up
        { duration: '1m', target: 500 }, // 1m at 300VU load
        { duration: '1m', target: 0 },
    ],
};

const API_BASE_URL = 'http://localhost:5190/pizza';

// run using `k6 run script.js`
export default () => {

    http.batch([
        ['GET', `${API_BASE_URL}/1`],
        ['GET', `${API_BASE_URL}/2`],
        ['GET', `${API_BASE_URL}/3`],
    ]);

    sleep(1);
};