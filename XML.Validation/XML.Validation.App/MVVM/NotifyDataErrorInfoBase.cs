﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XML.Validation.App.MVVM
{
    public abstract class NotifyDataErrorInfoBase : PropertyChangedBase, INotifyDataErrorInfo,
        INotifyPropertyChanged
    {

        #region Fields

        private readonly IDictionary<string, IReadOnlyCollection<string>> _errors;

        #endregion

        #region Constructors

        protected NotifyDataErrorInfoBase()
        {
            _errors = new Dictionary<string, IReadOnlyCollection<string>>();
        }

        #endregion

        #region Properties

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the validation errors for a specified property or for the entire entity.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to retrieve validation errors for; or <see cref="String.Empty"/>,
        /// to retrieve entity-level errors.
        /// </param>
        /// <returns>The validation errors for the property or entity.</returns>
        public virtual IEnumerable GetErrors(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
                return null;
            return _errors[propertyName];
        }

        /// <summary>
        /// Updates property value.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Storage of the property value.</param>
        /// <param name="value">New value for the property.</param>
        /// <param name="validator">Validation function to apply when updating the value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>true if storage value was changed; otherwise, false.</returns>
        protected bool SetValue<T>(ref T storage, T value, Func<T, IReadOnlyCollection<string>> validator,
            [CallerMemberName] string propertyName = null)
        {
            SetErrors(propertyName, validator(value));

            // ReSharper disable once ExplicitCallerInfoArgument
            return SetValue(ref storage, value, propertyName);
        }

        /// <summary>
        /// Updates errors collection for the specified property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="activeErrors">List of errors to set for the property.</param>
        protected void SetErrors(string propertyName, IReadOnlyCollection<string> activeErrors)
        {
            if (activeErrors == null || activeErrors.Count == 0)
            {
                _errors.Remove(propertyName);
            }
            else
            {
                _errors[propertyName] = activeErrors;
            }

            // Little trick here - raise the event despite of the changes, this allows to force validation by assigning property value back to itself
            OnErrorsChanged(propertyName);
        }

        /// <summary>
        /// Notifies all subscribers that property errors has been changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            if (handler != null)
                handler(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion
    }
}
