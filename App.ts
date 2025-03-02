import * as readline from 'readline';

// readlineインターフェースを作成
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

function input() {
    let result = "";
    rl.question("お名前は?：　", (answer) => {
      rl.close();
      result = answer;
    })
    return result;
  }

const a = input()
console.log(a)