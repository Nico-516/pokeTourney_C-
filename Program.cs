using System;
using Controller;

Console.WriteLine("PokeTourney active.");

Tourney tourney = CreateTourney.CreateNewTourneyWith16Trainers("SuperUltraTourney");
ManageTourney.TourneyManager(tourney);