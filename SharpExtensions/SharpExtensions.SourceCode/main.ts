///<reference path="./Scripts/typings/node/node.d.ts"/>

import fs = require("fs");

if (process.argv.length < 2) {
    var usage = [];
    usage.push("Usage");
    usage.push("  -clean <file> :: Cleans a Source Code file of Comments and Attributes");
    console.error(usage.join("\n"));
} else {
    switch (process.argv[0].toLowerCase()) {
        case "clean":
            fs.readFile(process.argv[0], (err: ErrnoException, file: NodeBuffer) => {
                var sourceCode: string = file.toString();

            });
        break;
    }
}

