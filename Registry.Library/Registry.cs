namespace Apollo.Web.Helpers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Registry class that allows for clean replacement of switch statements.
    /// </summary>
    public class Registry<T, TKey, TResult>
    {
        /// <summary>
        /// Returns a delegate to the function referenced under the key.
        /// </summary>
        /// <param name="key">The key used to select the item in the switch statement.</param>
        public Func<T, TResult> GetAction(TKey key)
        {
            Func<T, TResult> value;
            if (actions.TryGetValue(key, out value))
            {
                return value;
            }

            return defaultAction;
        }

        /// <summary>
        /// Adds a new function delegate to the list of options referenced by a key.
        /// </summary>
        /// <param name="key">The key used to select the item in the switch statement.</param>
        /// <param name="action">The function pointer to the function that will perform the selected action.</param>
        public void Register(TKey key, Func<T, TResult> action)
        {
            actions.Add(key, action);
        }

        /// <summary>
        /// Removes a function delegate from the list of options referenced by a key.
        /// </summary>
        /// <param name="key">The key used to select the item in the switch statement.</param>
        public bool Remove(TKey key)
        {
            return actions.Remove(key);
        }

        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear()
        {
            actions.Clear();
        }

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="defaultAction">The function delegate that is invoked when we call GetAction and the key is not found.</param>
        public Registry(Func<T, TResult> defaultAction)
        {
            this.defaultAction = defaultAction;
            actions = new Dictionary<TKey, Func<T, TResult>>();
        }

        /// <value>
        /// The delegate to the default action taken when key is not found.
        /// </value>
        private readonly Func<T, TResult> defaultAction;
        /// <value>
        /// A dictionary holding all the delegates to the actions.
        /// </value>
        private readonly Dictionary<TKey, Func<T, TResult>> actions;
    }
}