﻿using GuichetBanque_HelioBank.models;
using Client = GuichetBanque_HelioBank.models.Client;


namespace GuichetBanque_HelioBank.controllers;

public class ClientController
{
    public bool auth(string email, string password)
    {
        Client cred = new ClientModel().GetClient("email", email, "");
        Console.WriteLine(cred._firstName);
        if (password == cred._password)
        {
            kernel.Session._sessionId = cred._id;
            return true;
        }
        return false;
    }
}