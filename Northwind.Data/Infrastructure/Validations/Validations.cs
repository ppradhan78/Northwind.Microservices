using Northwind.Data.Infrastructure.Exceptions;
using System.Collections;
using System.Linq.Expressions;

namespace Northwind.Data.Infrastructure.Validations
{
    public static class Validations
    {
        #region Public Methods

        /// <summary>
        /// To validate integer values.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public static void ValidateId(int id, string message)
        {
            if (id <= 0)
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To Validate if text is valid interger 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public static void ValidateTextIsInteger(string input, string message)
        {
            if (!int.TryParse(input, out _))
            {
                ValidationException(message);
            }
        }

        public static void ValidateCollectionIsNotEmpty(ICollection value, string message)
        {
            if (value.Count == 0)
            {
                ValidationException(message);
            }
        }

        public static void ValidateCollectionIsNotNullOrEmpty(ICollection value, string message)
        {
            if (value == null || value.Count == 0)
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To validate integer values.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public static void ValidateId(int? id, string message)
        {
            if (id.HasValue)
            {
                ValidateId(id.Value, message);
            }

            else
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To validate integer values.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public static void ValidateIdIfPresent(int? id, string message)
        {
            if (id.HasValue)
            {
                ValidateId(id.Value, message);
            }
        }

        /// <summary>
        /// To validate string values.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="message"></param>
        public static void ValidateText(string text, string message)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To validate string values.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="withinValues"></param>
        /// <param name="message"></param>
        public static void ValidateText(string text, string[] withinValues, string message)
        {
            if (!withinValues.Contains(text))
            {
                ValidationException(message);
            }
        }


        /// <summary>
        /// To validate string length.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="message"></param>
        public static void ValidateTextLength(string text, int maxLength, string message)
        {
            if (!string.IsNullOrEmpty(text) && text.Length > maxLength)
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To validate date values.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="message"></param>
        public static void ValidateTextIsDate(string input, string message)
        {
            if (!DateTime.TryParse(input, out _))
            {
                ValidationException(message);
            }
        }


        /// <summary>
        /// To validate date values.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="message"></param>
        public static void ValidateDate(DateTime? date, string message, bool canBeFutureDate = true)
        {
            ValidateDate(date.Value, message, canBeFutureDate);
        }

        /// <summary>
        /// To validate date values.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="message"></param>
        public static void ValidateDate(DateTime date, string message, bool canBeFutureDate = true)
        {
            if (!canBeFutureDate && !IsValidPastDate(date) || canBeFutureDate && !IsValidDate(date))
            {
                ValidationException(message);
            }
        }
        public static void ValidateDate(DateTimeOffset date, string message, bool canBeFutureDate = true)
        {
            if (!canBeFutureDate && !IsValidPastDate(date) || canBeFutureDate && !IsValidDate(date))
            {
                ValidationException(message);
            }
        }
        /// <summary>
        /// To validate Start Date is less than or equal to End Date.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="message"></param>
        public static void ValidateDate1NotEarlierThanDate2(DateTime date1, DateTime date2, string message)
        {
            if (DateTime.Compare(date1, date2) < 0)
            {
                ValidationException(message);
            }
        }
        /// <summary>
        /// To validate Start Date is less than (Not Equal to) End Date.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="message"></param>

        public static void ValidateDate1NotEarlierThanOrEqualToDate2(DateTime date1, DateTime date2, string message)
        {
            if (DateTime.Compare(date1, date2) <= 0)
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To Validate Date 1 is within the Max days Range of Date2 
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="range"></param>
        /// <param name="message"></param>
        public static void ValidateDateWithinMaxRangeDaysOfDate2(DateTime date1,
            DateTime date2, int range, string message)
        {
            var startRanegDate = date2.AddDays(-range);
            if ((DateTime.Compare(date1.Date, startRanegDate.Date) < 0))
            {
                ValidationException(message);
            }
        }


        /// <summary>
        /// To validate Start Date is less than or equal to End Date.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="message"></param>
        public static void ValidateDate1NotEarlierThanDate2(DateTime? date1, DateTime? date2, string message)
        {
            if (date1.HasValue && date2.HasValue)
            {
                ValidateDate1NotEarlierThanDate2(date1.Value, date2.Value, message);
            }
        }

        /// <summary>
        /// To validate Start Date is less than or equal to End Date.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="message"></param>
        public static void ValidateDate1NotEarlierThanDate2(DateTime date1, DateTime? date2, string message)
        {
            if (date2.HasValue)
            {
                ValidateDate1NotEarlierThanDate2(date1, date2.Value, message);
            }
        }

        /// <summary>
        /// To validate Start Date is less than or equal to End Date.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="message"></param>
        public static void ValidateBirthDate(DateTime date1, string message)
        {
            if (DateTime.Compare(date1, DateTime.Now) > 0)
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To validate Start Date is less than or equal to End Date.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="message"></param>
        public static void ValidateDate1NotEarlierThanDate2(DateTime? date1, DateTime date2, string message)
        {
            if (date1.HasValue)
            {
                ValidateDate1NotEarlierThanDate2(date1.Value, date2, message);
            }
        }
        /// <summary>
        /// To validate Start Date is less than or equal to End Date.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="message"></param>
        public static void ValidateDate1NotEarlierThanDate2(DateTimeOffset? date1, DateTimeOffset date2, string message)
        {
            if (date1.HasValue)
            {
                if (DateTimeOffset.Compare(date1.Value, date2) < 0)
                {
                    ValidationException(message);
                }
            }
        }

        public static void ValidateDateWithin30Days(DateTime? date1, string message)
        {
            if (date1.HasValue)
            {
                ValidateDateWithin30Days(date1.Value, message);
            }
        }


        /// <summary>
        /// To Validate if given value is in Range 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="message"></param>
        public static void ValidateIsInRange(long? instance, long minValue, long maxValue, string message)
        {
            if (instance < minValue || instance > maxValue)
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// To Validate if given value exist in list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="validateList"></param>
        /// <param name="message"></param>
        public static void ValidateExistsInList<T>(T instance, List<T> validateList, string message)
        {
            if (validateList == null || validateList.Exists(c => instance.Equals(c)) == false)
            {
                ValidationException(message);
            }
        }

        /// <summary>
        /// Validates that the argument is not equal to null.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="message"></param>
        public static void ValidateIsNotNull(object instance, string message)
        {
            if (instance == null)
            {
                ValidationException(message);
            }
        }

        public static void ValidateIsNotNullOrWhitespace(string instance, string message)
        {
            if (string.IsNullOrWhiteSpace(instance))
            {
                ValidationException(message);
            }
        }

        public static void ValidateStringAsGuid(string id, string message, bool validateEmptyGuid = true)
        {
            if (!Guid.TryParse(id, out var newGuid) && (validateEmptyGuid && newGuid != Guid.Empty))
            {
                ValidationException(message);
            }
        }

        public static void ValidateBooleanWithExpectedValue(bool value, string message, bool expectedValue)
        {
            if (value != expectedValue)
            {
                ValidationException(message);
            }
        }
        /// <summary>
        /// To validate string is a valid datetime string
        /// </summary>
        /// <param name="dateTimeString"></param>
        /// <param name="dateTime"></param>
        /// <param name="message"></param>
        public static void ValidateDate(string dateTimeString, out DateTime dateTime, string message)
        {
            if (!DateTime.TryParse(dateTimeString, out dateTime))
            {
                ValidationException(message);
            }

        }
        /// <summary>
        /// Validates that the string represents Enum value.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="message"></param>
        public static void ValidateStringAsEnum<TEnum>(string text, string message) where TEnum : struct
        {

            if (!Enum.TryParse(text, out TEnum deliveryMethod))
            {
                ValidationException(message);
            }

        }

        public static void ValidateCollectionByPredicate<T>(IEnumerable<T> value, Expression<Func<T, bool>> pred, string message) where T : class
        {
            if (value.AsQueryable().Where(pred).Count() > 0)
            {
                ValidationException(message);
            }
        }

        #endregion

        #region Private Methods

        private static bool IsValidPastDate(DateTime datetime)
        {
            return !datetime.Equals(DateTime.MinValue) && datetime <= DateTime.Now;
        }
        private static bool IsValidPastDate(DateTimeOffset datetime)
        {
            return !datetime.Equals(DateTimeOffset.MinValue) && datetime <= DateTimeOffset.Now;
        }
        public static bool IsValidDate(DateTime datetime)
        {
            return !datetime.Equals(DateTime.MinValue);
        }
        public static bool IsValidDate(DateTimeOffset datetime)
        {
            return !datetime.Equals(DateTimeOffset.MinValue);
        }
        private static void ValidationException(string message)
        {
            throw new ValidationFailureException(message);
        }

        #endregion
    }
}
