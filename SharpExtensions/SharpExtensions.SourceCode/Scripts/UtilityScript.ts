/// <reference path="./typings/node/node.d.ts" />

import fs = require("fs");

module UtilityScript {

    export interface IScript {
        filePath: string;
        process(filePath: string): string;
        read(): void
    }

    export class BaseScript implements IScript {
        filePath: string;
        constructor(filePath: string) {
            this.filePath = filePath;
        }

        process: (fileContents: string) => string;

        read(): void {
            fs.readFile(this.filePath,
                DefaultCallbackHandlers.parameterizedHandler<NodeBuffer>((data: NodeBuffer) => {
                    console.info("Read File: %s", this.filePath);
                    fs.writeFile(this.filePath, this.process(data.toString()),
                        DefaultCallbackHandlers.handler((() => console.info("Processed File: %s", this.filePath))));
                }));
        }
    }

    export class DefaultCallbackHandlers {
        static parameterizedHandler<T>(callback: (handlerParam: T) => void): (err: ErrnoException, handlerParam: T) => void {
            return (err: ErrnoException, handlerParam: T) => {
                if (err) {
                    logCallbackError(err);
                } else {
                    callback(handlerParam);
                }
            };
        }

        static handler(callback: () => void): (err: ErrnoException) => void {
            return (err: ErrnoException) => {
                if (err) {
                    logCallbackError(err);
                } else {
                    callback();
                }
            };
        }
    }

    export function makeParameterizedCallbackHandler<T>(callback: (handlerParam: T) => void): (err: ErrnoException, handlerParam: T) => void {
        return (err: ErrnoException, handlerParam: T) => {
            if (err) {
                logCallbackError(err);
            } else {
                callback(handlerParam);
            }
        };
    }

    export function makeCallbackHandler(callback: () => void): (err: ErrnoException) => void {
        return (err: ErrnoException) => {
            if (err) {
                logCallbackError(err);
            } else {
                callback();
            }
        };
    }

    export function logCallbackError(err: ErrnoException) {
        console.error([
                "Error %s Logged.",
                "Number: %d",
                "Message: %s",
                "Path: %s",
                "Code: %s",
                "System Call: %s"
            ].join('\n'),
            err.name,
            err.errno,
            err.message,
            err.path,
            err.code,
            err.syscall);
    }

    export function logError(err: Error) {
        console.error([
                "Error %s Logged.",
                "Message: %s",
            ].join('\n'),
            err.name,
            err.message);
    }
}