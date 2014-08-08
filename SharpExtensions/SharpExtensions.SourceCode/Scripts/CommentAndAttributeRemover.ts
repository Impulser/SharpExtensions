///<reference path="./UtilityScript.ts"/>
///<reference path="./typings/node/node.d.ts"/>

import us = require("UtilityScript");
import fs = require("fs");


class CommentAndAttributeRemover extends  us.BaseScript {
    filePath: string;
    fileContents: string;
    callbackHandler<TParam>(err: ErrnoException, fileBuffer: TParam): boolean;

    constructor(filePath: string) {
        this.filePath = filePath;
        this.
    }

    read(): void {
        fs.readFile(this.filePath, (err: ErrnoException, fileBuffer: NodeBuffer) => {
            
        });
    }

    process(fileContents: string): string {
        
    }
     
}