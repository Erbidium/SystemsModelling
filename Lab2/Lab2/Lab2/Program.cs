using Lab2;

var c = new Create(2.0);
var p = new Process(1.0);

Console.WriteLine($"Id0 = {c.Id}  Id1 = {p.Id}");

c.NextElement = p;
p.MaxQueue = 5;
c.Name = "CREATOR";
p.Name = "PROCESSOR";
c.Distribution = "exp";
p.Distribution = "exp";

var list = new List<Element>{ c, p };

var model = new Model(list);
model.Simulate(1000);