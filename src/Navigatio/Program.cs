﻿using Navigatio;
using Navigatio.Storages;
using static System.IO.Path;

// TODO:
// add help

string exePath = AppContext.BaseDirectory;

var aliases = new JsonStorage<Dictionary<string, string>>(
    Join(exePath, "aliases.json"));
var historyStorage = new JsonStorage<LinkedList<(string, object)>>(
    Join(exePath, "history.json"));
var history = new History(historyStorage);
var commander = new Commander(aliases, history, Join(exePath, "output.sh"));

var app = new Application(args, commander, history);
app.Run();
