﻿namespace Persistence.Entities.v1;

//ToDo - create a separate nom table
public class EngineVolume
{
    public int Id { get; set; }

    public string Description { get; set; }

    public decimal Multiplier { get; set; }
}