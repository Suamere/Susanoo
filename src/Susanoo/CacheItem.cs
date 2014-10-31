﻿using System;

namespace Susanoo
{
    public class CacheItem
    {
        private readonly object _item;

        public object Item
        {
            get
            {
                CallCount++;
                return _item;
            }
        }

        public CacheMode CachingMode { get; private set; }

        public double Interval { get; private set; }

        public int CallCount { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public CacheItem(object item, CacheMode mode = CacheMode.Permanent, double? interval = null)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            _item = item;
            CachingMode = mode;
            Interval = interval != null ? interval.Value : 0d;

            TimeStamp = DateTime.Now;

            if (Interval <= 0)
                CachingMode = CacheMode.Permanent;
        }

        /// <summary>
        /// Renews the intervals.
        /// </summary>
        public void RenewIntervals()
        {
            CallCount = 0;
            TimeStamp = DateTime.Now;
        }
    }

    /// <summary>
    /// Caching modes supported by Susanoo
    /// </summary>
    public enum CacheMode
    {
        None = 0,
        Permanent,
        TimeSpan,
        RepeatedRequestLimit
    }
}