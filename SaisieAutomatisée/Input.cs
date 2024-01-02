using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SaisieAutomatisée
{
   public static class Input
   {
      public static void SaisirValeursProprietés<T>(T entity) where T : class
      {
         if (entity != null)
         {


            Type type = typeof(T);
            Console.WriteLine($"formulaire {type.Name}:");
            foreach (PropertyInfo pi in entity.GetType().GetProperties())
            {

               foreach (Attribute attribut in pi.GetCustomAttributes())
               {
                  if (attribut is DisplayAttribute displayAttribute)
                  {
                     bool erreur;
                     do
                     {
                        try
                        {

                           erreur = false;
                           Console.WriteLine(displayAttribute.Prompt);
                           string? res = Console.ReadLine();
                           if (res != null)
                           {


                              pi.SetValue(entity, Convert.ChangeType(res, pi.PropertyType), null);

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
                        catch (TargetInvocationException ve)
                        {
                           Console.WriteLine(ve.InnerException?.Message);
                           erreur = true;
                        }
                        catch (Exception)
                        {

                           erreur = true;
                        }


                     } while (erreur);



                  }




               }

            }
         }
      }
   }
}
