namespace Apollo.Web.Helpers
{
    using System;
    using System.Collections.Generic;

    public class Registry<T, TKey, TResult>
    {
        public Func<T, TResult> GetAction(TKey key)
        {
            Func<T, TResult> value;
            if (actions.TryGetValue(key, out value))
            {
                return value;
            }

            return defaultAction;
        }

        public void Register(TKey key, Func<T, TResult> action)
        {
            actions.Add(key, action);
        }

        public bool Remove(TKey key)
        {
            return actions.Remove(key);
        }

        public void Clear()
        {
            actions.Clear();
        }

        public Registry(Func<T, TResult> defaultAction)
        {
            this.defaultAction = defaultAction;
            actions = new Dictionary<TKey, Func<T, TResult>>();
        }

        private readonly Func<T, TResult> defaultAction;
        private readonly Dictionary<TKey, Func<T, TResult>> actions;
    }
}