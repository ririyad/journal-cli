﻿using NodaTime;
using NodaTime.Extensions;

namespace JournalCli.Library.Infrastructure
{
    internal static class Now
    {
        public static LocalTime Time() => SystemClock.Instance.InTzdbSystemDefaultZone().GetCurrentLocalDateTime().TimeOfDay;
    }
}