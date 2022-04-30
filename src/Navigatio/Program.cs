﻿using Navigatio;
using Navigatio.Storages;
using static System.IO.Path;

// TODO:
// add ICommandHolder interface ?
// add error handling (command usage exception, etc.)
// add config
// add more info about command execution
// optimize file IO
// make history limit ?

string exePath = AppContext.BaseDirectory;
var aliases = new JsonStorage<Dictionary<string, string>>(
    Join(exePath, "aliases.json"));
var historyStorage = new JsonStorage<LinkedList<(string, object)>>(
    Join(exePath, "history.json"));

var history = new History(historyStorage);
var table = new Table();

var commander = new Commander(aliases, history, table, Join(exePath, "output.sh"));
commander.Execute(args);
