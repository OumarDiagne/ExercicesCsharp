using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SaisieAutomatisée
{
   public static class ClientHelper
   {
      public static void SaisirValeursClientForm(this Client client)
      {

         if (client != null)
         {
            bool erreur;
            do
            {
               erreur = false;

               Type type = typeof(Client);
               Console.WriteLine($"formulaire {type.Name}:");
               foreach (PropertyInfo pi in client.GetType().GetProperties())
               {

                  foreach (Attribute attribut in pi.GetCustomAttributes())
                  {
                     if (attribut is DisplayAttribute displayAttribute)
                     {
                        try
                        {
                           Console.WriteLine(displayAttribute.Prompt);
                           string? res = Console.ReadLine();
                           if (res != null)
                           {


                              pi.SetValue(client, Convert.ChangeType(res, pi.PropertyType), null);

                           }

                        }
                        catch (OverflowException)
                        {
                           Console.WriteLine("le nombre saisi est trop grand");
                           erreur = true;
                        }
                        catch (FormatException)
                        {
                           Console.WriteLine("format de donnée non valide");
                           erreur = true;
                        }
                        catch (ValidationException ve)
                        {
                           Console.WriteLine(ve.Message);
                           erreur = true;
                        }
                     }

                  }

               }




            } while (erreur);

         }
      }
   }
}
