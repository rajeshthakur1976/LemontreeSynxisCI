//-----------------------------------------------------------------------
// <copyright file="Utility.cs" company="Toyota Kirloskar ">
//     Copyright (c) Toyota Kirloskar Motor 2015-2017. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Framework.SynxisCI.Common
{
    public static class Utility
    {
        private static XmlWriterSettings DefaultXmlWriterSettings = new XmlWriterSettings()
        {
            Encoding = Encoding.UTF8,
            Indent = false,
            OmitXmlDeclaration = true,
            WriteEndDocumentOnClose = true,
            NewLineHandling = NewLineHandling.None,
            NamespaceHandling = NamespaceHandling.Default,
        };
                
        public static T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }

        public static bool TrySerialize(dynamic deserializedValue, out string serializedObject)
        {
            try
            {
                var sb = new StringBuilder();
                //var ns = new XmlSerializerNamespaces();
                //ns.Add(string.Empty, string.Empty);
                using (var writer = XmlWriter.Create(sb, DefaultXmlWriterSettings))
                {
                    XmlSerializer serializer = new XmlSerializer(deserializedValue.GetType());
                    serializer.Serialize(writer, deserializedValue);
                }
                serializedObject = sb.ToString();
                return true;
            }
            catch (Exception ex)
            {
                // To do
                // Log exception here.
                serializedObject = null;
                return false;
            }
        }

        public static string Serialize(dynamic deserializedValue)
        {
            string serializedValue;
            TrySerialize(deserializedValue, out serializedValue);
            return serializedValue;
        }
        /// <summary>
        /// Validates xml
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="sr"> xsd stream reader</param>
        /// <returns></returns>
        public static bool ValidateXML(string xml, StreamReader sr)
        {

            //var sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(xsdFile));


            var schemaSet = new XmlSchemaSet();
            schemaSet.Add("", XmlReader.Create(new StringReader(sr.ReadToEnd())));
            var settings = new XmlReaderSettings()
            {
                Schemas = schemaSet,
                ValidationType = ValidationType.Schema,
            };

            var response = string.Empty;
            if (string.IsNullOrWhiteSpace(xml))
                return false;

            var reader = XmlReader.Create(new StringReader(xml), settings);
            try
            {
                var doc = XDocument.Load(reader);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        // The assemblyFormatter parameter is normally not passed in. However, it may be passed in for cases where the type is a special case (such as for enumerables or structs) that needs to be passed into the serializer. If this is the case, this value should be passed in as yourObject.GetType().FullName.
        /*
        public static bool TryDeserialize(string serializedObject, out dynamic deserializedObjectOut, string assemblyFormatter = "System.{0}")
        {
            try
            {
                StringReader reader = new StringReader(serializedObject);
                XDocument document = XDocument.Load(reader);
                string typeString = null;
                // Map the object type to the System's default value types.
                if (document.Root != null)
                {
                    switch (document.Root.Name.LocalName)
                    {
                        case "string":
                            typeString = "String";
                            break;
                        case "dateTime":
                            typeString = "DateTime";
                            break;
                        case "int":
                            typeString = "Int32";
                            break;
                        case "unsignedInt":
                            typeString = "UInt32";
                            break;
                        case "long":
                            typeString = "Int64";
                            break;
                        case "unsignedLong":
                            typeString = "UInt64";
                            break;
                        case "boolean":
                            typeString = "Boolean";
                            break;
                        case "double":
                            typeString = "Double";
                            break;
                        case "float":
                            typeString = "Single";
                            break;
                        case "decimal":
                            typeString = "Decimal";
                            break;
                        case "char":
                            typeString = "Char";
                            break;
                        case "short":
                            typeString = "Int16";
                            break;
                        case "unsignedShort":
                            typeString = "UInt16";
                            break;
                        case "byte":
                            typeString = "SByte";
                            break;
                        case "unsignedByte":
                            typeString = "Byte";
                            break;
                    }
                    if (assemblyFormatter != "System.{0}")
                    {
                        typeString = document.Root.Name.LocalName;
                    }
                }
                if (typeString == null)
                {
                    // The dynamic object's type is not supported.
                    deserializedObjectOut = null;
                    return false;
                }
                if (typeString == "String")
                {
                    // System.String does not specify a default constructor.
                    XmlSerializer serializer = new XmlSerializer(typeof(String));
                    reader = new StringReader(serializedObject);
                    deserializedObjectOut = serializer.Deserialize(reader);
                }
                else
                {
                    object typeReference;
                    if (assemblyFormatter != "System.{0}")
                    {
                        typeReference = Activator.CreateInstance(Type.GetType(assemblyFormatter));
                    }
                    else
                    {
                        typeReference = Activator.CreateInstance(Type.GetType(String.Format(assemblyFormatter, typeString)));
                    }
                    XmlSerializer serializer = new XmlSerializer(typeReference.GetType());
                    reader = new StringReader(serializedObject);
                    deserializedObjectOut = serializer.Deserialize(reader);
                }
                return true;
            }
            catch
            {
                deserializedObjectOut = null;
                return false;
            }
        }
        */
        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                return string.Empty;
            }
            return match.Groups[1].Value + domainName;
        }

        /// <summary>
        /// Validates an email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidEmail(string email)
        {
            bool valid = false;
            if (string.IsNullOrEmpty(email))
                return valid;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return valid;
            }

            // Return true if strIn is in valid e-mail format.
            try
            {
                valid = Regex.IsMatch(email,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                valid = false;
            }
            return valid;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string ordering, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }

        public static IDictionary<Tkey, TValue> AddIfNotExists<Tkey, TValue>(this IDictionary<Tkey, TValue> source, Tkey key, TValue value)
        {
            if (!source.ContainsKey(key))
                source.Add(key, value);

            return source;
        }

        public static DateTime ConvertUtcToIst(DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }

        public static DateTimeOffset ConvertUtcToIstWithOffset(DateTime utcDateTime)
        {
            return new DateTimeOffset(TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")), TimeZoneInfo.FindSystemTimeZoneById("India Standard Time").BaseUtcOffset);
        }

        public static DateTime? ConvertUtcToIstNullable(DateTime? utcDateTime)
        {
            if (utcDateTime == null)
                return null;
            return ConvertUtcToIst(utcDateTime.Value);
        }

        public static DateTimeOffset? ConvertUtcToIstWithOffsetNullable(DateTime? utcDateTime)
        {
            if (utcDateTime == null)
                return null;
            return ConvertUtcToIstWithOffset(utcDateTime.Value);
        }

        public static DateTime ConvertIstToUtc(DateTime istDateTime)
        {
            return TimeZoneInfo.ConvertTimeToUtc(istDateTime, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }

        public static DateTime? ConvertIstToUtcNullable(DateTime? istDateTime)
        {
            if (istDateTime == null)
                return null;
            return ConvertIstToUtc(istDateTime.Value);
        }

        private static string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(
                typeof(DisplayNameAttribute), true);
            if (atts.Length == 0)
                return property.Name;
            return (atts[0] as DisplayNameAttribute).DisplayName;
        }
        public static string GetCSV<T>(this IList<T> list)
        {
            StringBuilder sb = new StringBuilder();

            //Get the properties for type T for the headers
            PropertyInfo[] propInfos = typeof(T).GetProperties();
            for (int i = 0; i <= propInfos.Length - 1; i++)
            {
                sb.Append(GetAttributeDisplayName( propInfos[i]));

                if (i < propInfos.Length - 1)
                {
                    sb.Append(",");
                }
            }

            sb.AppendLine();

            //Loop through the collection, then the properties and add the values
            for (int i = 0; i <= list.Count() - 1; i++)
            {
                T item = list[i];
                for (int j = 0; j <= propInfos.Length - 1; j++)
                {
                    object o = item.GetType().GetProperty(propInfos[j].Name).GetValue(item, null);
                    if (o != null)
                    {
                        string value = o.ToString();

                        //Check if the value contans a comma and place it in quotes if so
                        if (value.Contains(","))
                        {
                            value = string.Concat("\"", value, "\"");
                        }

                        //Replace any \r or \n special characters from a new line with a space
                        if (value.Contains("\r"))
                        {
                            value = value.Replace("\r", " ");
                        }
                        if (value.Contains("\n"))
                        {
                            value = value.Replace("\n", " ");
                        }

                        sb.Append(value);
                    }

                    if (j < propInfos.Length - 1)
                    {
                        sb.Append(",");
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static TimeSpan ConvertStringToTimeSpan(string Datestring)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datestring))
                {
                    var twelveHrs = TimeSpan.FromHours(12);
                    var timestring = Datestring.Substring(0, Datestring.Length - 2);
                    var isPM = Datestring.Replace(timestring, "").ToLower().Contains("pm");
                    var hours = int.Parse(timestring.Split(':')[0]);
                    if (isPM)
                    {
                        if (hours == 12)
                            return TimeSpan.Parse(timestring);
                        else
                            return TimeSpan.Parse(timestring).Add(twelveHrs);
                    }
                    else
                    {
                        if (hours == 12)
                            return TimeSpan.Parse(timestring).Subtract(twelveHrs);
                        else
                            return TimeSpan.Parse(timestring);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return new TimeSpan();
        }

        public static T GetObjectFromXmlString<T>(string xmlString)
        {
            xmlString = xmlString.Replace("< ", "<");
            xmlString = xmlString.Replace(" >", ">");
            xmlString = xmlString.Replace("</ ", "</");
            xmlString = xmlString.Replace(" <", "<");
            xmlString = xmlString.Replace("> ", ">");

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            var xmlReader = new XmlNodeReader(xmlDoc.DocumentElement);
            var xmlSerializer = new XmlSerializer(typeof(T));
            var obj = xmlSerializer.Deserialize(xmlReader);
            //obj = HttpUtility.HtmlEncode(obj);

            return (T)obj;
        }

        public static DateTime GetDefaultDate(DateTime? dateValue)
        {
            DateTime defaultDate = DateTime.Parse("01/01/1753");
            dateValue = dateValue ?? defaultDate;
            if (dateValue < defaultDate)
                return defaultDate;
            else
                return dateValue.Value;
        }

    }
}
