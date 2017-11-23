using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1;
using App1.Droid;
using Java.Security;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(Calendario))]

namespace App1.Droid
{
    class Calendario : EventoCalendario
    {
        public async void AggiuntaEventoCalendario()
        {
            await AddAppointment();
        }

        public async Task<bool> AddAppointment()
        {
            Intent intent = new Intent(Intent.ActionInsert);
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, "prova");
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.Description,
                "This is an event created from Xamarin.Android");
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart,
                GetDateTimeMS(2017, 12, 15, 10, 0));
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend,
                GetDateTimeMS(2017, 12, 15, 10, 15));
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");
            intent.SetData(CalendarContract.Events.ContentUri);
            ((Activity) Forms.Context).StartActivity(intent);
            return true;
        }

        long GetDateTimeMS(int yr, int month, int day, int hr, int min)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(CalendarField.DayOfMonth, 15);
            c.Set(CalendarField.HourOfDay, hr);
            c.Set(CalendarField.Minute, min);
            c.Set(CalendarField.Month, Calendar.December);
            c.Set(CalendarField.Year, 2017);

            return c.TimeInMillis;
        }
    }
}
