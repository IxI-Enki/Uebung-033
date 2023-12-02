/*------------------------------------------------------------------------------
 *                      HTBLA-Leonding / Class: 3ACIF
 *------------------------------------------------------------------------------
 *                      Jan Ritt
 *------------------------------------------------------------------------------
 *  Description:  The program reads in the distance between two cars and the
 *                velocity of both of them and calulates their distance to each
 *                other for every minute.
 *------------------------------------------------------------------------------
*/
using System;
using System.Threading;

namespace LinearMotion
{
  internal class Programm
  {
    static void Main()
    {
      /*  SET SCREEN  */
      const int consoleWidth = 70;
      const int consoleHeight = 30;
      Console.SetWindowSize(consoleWidth, consoleHeight);

      /*  VARIABLES  */
      string userInput,
             formattedDistance, formattedDistanceA, formattedDistanceB,
             formattedTime;
      int distance, time,
          hours, minutes;
      double speedCarA, speedCarB,
             distanceInAMinuteA, distanceInAMinuteB, totalDistancePerMinute,
             totalTimeRequired, meetingPoint, seconds;

      /*  INPUT  */
      Console.Write("\n               Begegnung zweier entgegenfahrender Autos               " +
                    "\n======================================================================" +
                    "\n Entfernung [Ganzzahl in km]: ");
      userInput = Console.ReadLine();
      int.TryParse(userInput, out distance);

      Console.Write("\n Geschwindigkeit Fahrzeug A [Ganzzahl in km/h ]: ");
      userInput = Console.ReadLine();
      double.TryParse(userInput, out speedCarA);

      Console.Write("\n Geschwindigkeit Fahrzeug B [Ganzzahl in km/h ]: ");
      userInput = Console.ReadLine();
      double.TryParse(userInput, out speedCarB);

      /*  CALCULATE ONE MINUTE  */
      distanceInAMinuteA = speedCarA / 60;
      distanceInAMinuteB = speedCarB / 60;
      totalDistancePerMinute = distanceInAMinuteA + distanceInAMinuteB;
      totalTimeRequired = distance / totalDistancePerMinute;
      Console.Write("----------------------------------------------------------------------");

      for (time = 0; time < totalTimeRequired; time++)
      {
        formattedTime = time.ToString().PadLeft(4);
        formattedDistanceA = (distanceInAMinuteA * time).ToString("0.00").PadLeft(6);
        formattedDistanceB = (distance - distanceInAMinuteB * time).ToString("0.00").PadLeft(6);
        formattedDistance = ((distance - distanceInAMinuteB * time) - (distanceInAMinuteA * time)).ToString("0.00").PadLeft(6);
        /*  OUTPUT EVERY POSITION EVERY MINUTE  */
        Console.Write($"\n Minute: {formattedTime}  Position A: {formattedDistanceA}  Position B: {formattedDistanceB}  Distanz: {formattedDistance} ");
      }
      /*  CALCULATE EXACT TRAVEL TIME  */
      hours = (int)(totalTimeRequired / 60);
      minutes = (int)(totalTimeRequired % 60);
      seconds = (double)((totalTimeRequired % 1) * 60);
      /*  CALCULATE MEETINGPOINT  */
      meetingPoint = totalTimeRequired * distanceInAMinuteA;
      /*  OUTPUT MEETING  */
      Console.Write("\n----------------------------------------------------------------------" +
                   $"\nTreffpunkt: {meetingPoint.ToString("0.00")} km nach {hours} Stunden, {minutes} Minuten, {seconds.ToString("0.00")} Sekunden");
      Console.Write("\n======================================================================");
      /*  END  */
      Console.Write("\nZum Beenden bitte Eingabetaste drücken ...");
      Console.ReadLine();
      Console.Clear();
    }
  }
}