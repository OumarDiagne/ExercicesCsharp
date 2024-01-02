namespace RelevesMeteos2
{
   public class RelevéMensuel
   {
      public const string EnteteTableau = """
                  Mois    | Tmin (°C) | Tmax (°C) | Tmoy (°C) | Vent (km/h) | Soleil (H) | Pluie (mm)
         -----------------------------------------------------------------------------------
         """;


      public int Mois { get; init; }
      public int Année { get; init; }
      public float Tmin { get; init; }
      public float Tmax { get; init; }
      public float Tmoy { get; init; }
      public float Vent { get; init; }
      public float Soleil { get; init; }
      public float Pluie { get; init; }

      public override string ToString()
      {
         return $"""
            {Mois}/{Année}| {Tmin,6} | {Tmax,6}  | {Tmoy,6} | {Vent,6} | {Soleil,6} | {Pluie,6}

            """;
      }
   }
}
