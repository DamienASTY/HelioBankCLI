// See https://aka.ms/new-console-template for more information

using GuichetBanque_HelioBank.controllers;
using GuichetBanque_HelioBank.kernel;
using GuichetBanque_HelioBank.models;

Console.WriteLine("Banking CLI");

bool connected = Factory.setConnection("heliobank", "root", "");
if (connected)
{
    Console.WriteLine("Database connected");
}
else
{
    Console.WriteLine("Error during database connection");
}

ClientController cltrl = new ClientController();
if (cltrl.auth("dpdp@example.com", "Berna123*"))
{
    Console.WriteLine("Successfully logged");
}
else
{
    Console.WriteLine("Invalid credentials");
}

Console.WriteLine(Session._sessionId);

//ClientModel mvc = new ClientModel();
//Client  client = mvc.GetClient("email", "dpdp@example.com", "");
