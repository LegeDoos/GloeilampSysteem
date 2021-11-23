/*
 * Rob Cilissen-Grassére, 20210225
 * 
 */
using System;

namespace GloeilampSysteem
{
    class Program
    {
        static void Main(string[] args)
        {
            // maak een instantie s van class schakelaar
            //Schakelaar s = new Schakelaar();
            Dimschakelaar schakelaar = new Dimschakelaar();
            Lamp lamp = new Lamp();

            schakelaar.VoegLampToe(lamp);

            // toon de status van de lampen
            schakelaar.ToonStatus();

            // toggle de schakelaar
            Console.WriteLine("Toggle de schakelaar:");
            schakelaar.Toggle();

            // toon de status van de lampen opnieuw
            schakelaar.ToonStatus();

            // verhoog dimmer
            schakelaar.Hoger();
            schakelaar.Hoger();
            schakelaar.Hoger();
            schakelaar.Hoger();
            schakelaar.ToonStatus();
            
            schakelaar.Lager();
            schakelaar.Lager();
            schakelaar.ToonStatus();

            

        }
    }
}
