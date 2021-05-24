/**
 * Reflection utility class
 *
 * @author Ivanir Joao Kreuzberg
 *
 * @class
 * @name Reflection
 */
function Reflection() {
}

/**
 * Class name to types
 *
 * @type Object
 *
 * @name TYPES
 * @member Reflection
 */
Reflection.TYPES = {
    "[object Boolean]": "boolean",
    "[object Number]": "number",
    "[object String]": "string",
    "[object Function]": "function",
    "[object Array]": "array",
    "[object Date]": "date",
    "[object RegExp]": "regexp",
    "[object Object]": "object"
};

/**
 * Convert the given Object instance to its named type. The following types are
 * supported:
 *
 * <ul>
 * <li><b>Boolean</b> => boolean</li>
 * <li><b>Number</b> => number</li>
 * <li><b>Function</b> => function</li>
 * <li><b>Array</b> => array</li>
 * <li><b>Date</b> => date</li>
 * <li><b>Regexp</b> => regexp</li>
 * <li><b>*</b> => object</li>
 * </ul>
 *
 * @param obj
 *            the object we want the named type for
 *
 * @return named type for the given object instance.
 */
Reflection.type = function (obj) {

    if (obj === null || obj === undefined) {
        return "null";
    }

    return Reflection.TYPES[Object.prototype.toString.call(obj)] || "object";
};

/**
 * Check rather the given value is in fact a Javascript <code>function</code>
 * or not.
 *
 * @param value
 *            the value being checked
 *
 * @return <code>true</code> if considered a callable function,
 *         <code>false</code> otherwise
 */
Reflection.isFunction = function (value) {

    return Reflection.type(value) === "function";
};

/**
 * Object utilities enables a single way of interpreting, reading and writting
 * properties from a hash object or XML node.
 *
 * @author Ivanir Joao Kreuzberg
 */
var Objects = {

    isXML: function (object) {

        return typeof object.nodeName != "undefined";
    },

    get: function (record, name) {

        if (Objects.isXML(record)) {

            return record.getAttribute(name);
        } else {

            return record[name];
        }
    },

    set: function (record, name, value) {

        if (Objects.isXML(record)) {

            record.setAttribute(name, value);
        } else {

            record[name] = value;
        }
    },

    getFields: function (record) {

        var fields = [];

        if (Objects.isXML(record)) {

            return record.attributes;
        } else {

            for (var name in record) {

                fields.push({
                    name: name,
                    value: record[name]
                });
            }
        }

        return fields;
    },

    /**
     * Check if the given object is a defined value by comparing against
     * <code>null</code> and <code>undefined</code> returning
     * <code>true</code> when neither or <code>false</code> otherwise.
     *
     * @param object
     *            {Object} the object being validated
     *
     * @return {Boolean} true if neither null or undefined, false otherwise.
     */
    isDefined: function (object) {

        return object !== undefined && object !== null;
    }
};

/**
 * Enables object/array navigation by visiting members of the given object using
 * a callback function as a way of looping through properties defined in a Hash
 * Object or elements of an Array.
 *
 * @param object
 *            the object being looped.
 *
 * @param callback
 *            function called for every encountered member of the given
 *            object/array. The callback uses the signature
 *            <code>(name, value)</code> for visited properties of a hash
 *            object and <code>(index, value)</code> for array elements.
 *
 * @param scope
 *            the scope used while calling the callback function. If not
 *            provided, the object being visited is used instead.
 */
Objects.each = function (object, callback, scope) {

    if (Objects.isDefined(object)) {

        var length = object.length;
        var isObject = length === undefined || Reflection.isFunction(object);

        if (!isObject) {

            for (var i = 0; i < length; i++) {

                if (callback.call(scope || object[i], i, object[i]) === false) {
                    break;
                }
            }

        } else {

            for (var name in object) {

                if (callback.call(scope || object[name], name, object[name]) === false) {
                    break;
                }
            }
        }
    }

    return object;
};

/**
 * Verify if the given string ends with the given value
 *
 * @param string
 *            {String} the string we are verifying
 *
 * @param value
 *            {String} the value used while comparing
 *
 * @param caseSensitive
 *            flag that indicates if we should perform comparison using case
 *            sensitive
 *
 * @return {Boolean} true if the given string ends with the given value, false
 *         otherwise
 */
Strings.endsWith = function (string, value, caseSensitive) {

    if (caseSensitive === false) {
        string = string.toLowerCase();
        value = value.toLowerCase();
    }

    return string.length > value.length
                    && string.indexOf(value) == (string.length - value.length);
};

/**
 * Trim both left and right sides of the given string removing trailing and
 * white space characters.
 *
 * @param string
 *            {String} the String value being processed
 *
 * @return {String} trimmed string
 */
Strings.trim = function (string) {

    if (!Objects.isDefined(string)) {
        return "";
    }

    /*
     * use native trim whenever possible
     */
    if (String.prototype.trim) {

        return string.trim();
    }

    return string.toString().replace(Strings.TRIM_LEFT, "").replace(
                    Strings.TRIM_RIGHT, "");
};

/*
 * Browser support
 */
function Browser() {
}

/**
 * Plug-in that enable quick access for reading and writing browser cookies.
 *
 * @param name
 *            the name of the cookie key used to identify the cookie
 *
 * @param value
 *            the value being written (only necessary while writing)
 *
 * @param options
 *            hash object holding options used while writing the given data to
 *            your cookie. You may define the following properties:
 *            <ul>
 *            <li>expires: as date or number holding the time to live applied
 *            to your cookie</li>
 *            <li>path: the path your cookie will be stored with</li>
 *            <li>domain: the domain your cookie will be stored with</li>
 *            <li>secure: boolean telling us if your cookie is secured or not</li>
 *            </ul>
 *
 * @return cookie value while reading (undefined while writing)
 *
 * @member Browser
 */
Browser.cookie = function (name, value, options) {

    /*
     * name and value given, set cookie
     */
    if (typeof value != 'undefined') {

        var expires = '';

        options = options || {};

        if (!Objects.isDefined(value)) {
            value = '';
            options.expires = -1;
        }

        if (options.expires
                        && (typeof options.expires == 'number' || options.expires.toUTCString)) {

            var date;

            if (typeof options.expires == 'number') {

                date = new Date();
                date.setTime(date.getTime()
                                + (options.expires * 24 * 60 * 60 * 1000));

            } else {

                date = options.expires;
            }
            /*
             * use expires attribute, max-age is not supported by IE
             */
            expires = '; expires=' + date.toUTCString();
        }

        /*
         * CAUTION: Needed to parenthesize options.path and options.domain in
         * the following expressions, otherwise they evaluate to undefined in
         * the packed version for some reason...
         */
        var path = options.path ? '; path=' + (options.path) : '';
        var domain = options.domain ? '; domain=' + (options.domain) : '';
        var secure = options.secure ? '; secure' : '';

        document.cookie = [name, '=', encodeURIComponent(value), expires,
                        path, domain, secure].join('');

    } else {

        /*
         * only name given, get cookie
         */
        var cookieValue = null;

        if (document.cookie && document.cookie !== '') {

            var cookies = document.cookie.split(';');

            for (var i = 0; i < cookies.length; i++) {

                var cookie = hoTrim(cookies[i]);

                /*
                 * Does this cookie string begin with the name we want?
                 */
                if (cookie.substring(0, name.length + 1) == (name + '=')) {

                    cookieValue = decodeURIComponent(cookie
                                    .substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};

/*
 * local storage support
 */

/**
 * API that wrappers <code>localStorage</code> falling back to regular browser
 * cookies when the same is not available.
 *
 * <p>
 * Another important aspect of this API is that it allows you to storage
 * full-complex Javascript Object instances (including arrays, numbers, etc). In
 * other words, JSON-based data.
 * </p>
 *
 * @author Ivanir Joao Kreuzberg
 *
 * @class
 * @name LocalStorage
 */
function LocalStorage() {
}

/*
 * create private scope so we can implement internal logic
 */
(function () {

    /**
     * Storage type being used
     */
    var type = null;

    /**
     * API defining the basic signature methods to read, write, remove and
     * verify local stored values.
     */
    var api = null;

    var construct = function (storageType) {

        type = storageType;

        if (!LocalStorage.isCookie()) {

            var storage = window.localStorage;

            api = {

                get: function (name) {

                    var value = storage.getItem(name);

                    if (Objects.isDefined(value)) {
                        value = JSON.parse(value);
                    }
                    return value;
                },

                set: function (name, value) {

                    if (Objects.isDefined(value)) {
                        value = JSON.stringify(value);
                    }

                    return storage.setItem(name, value);
                },

                contains: function (name) {

                    return Objects.isDefined(storage.getItem(name));
                },

                remove: function (name) {

                    storage.removeItem(name);
                },

                clear: function () {

                    storage.clear();
                }
            };

        } else {

            var maxLength = 400;

            var getKey = function (name, i) {

                if (i > 0) {

                    return name + "[" + i + "]";
                }

                return name;
            };

            /**
             * Encapsulate API around browser's cookie. Now, because cookies can
             * be very 1994, therefore very limited we can't store large values
             * on a single-cookie as it extrapolates the maximum allowed length.
             * So what we do is to merge it
             */
            api = {

                saveSearch: function (name) {
                    alert(name)
                    var parameters = {}
                    $("form input").each(function () {
                        if (this.type == "checkbox") {
                            parameters[this.id] = this.checked;
                        } else {
                            parameters[this.id] = this.value;
                        }
                    });
                    LocalStorage.set(name, parameters)
                },

                get: function (name) {

                    var values = [];

                    while (true) {

                        var key = getKey(name, values.length);

                        var value = Browser.cookie(key);

                        if (value) {

                            values.push(value);

                        } else {

                            break;
                        }
                    }

                    var value = values.join("");

                    return value.length === 0 ? null : JSON.parse(value);
                },

                set: function (name, value) {

                    if (value != null && value != undefined) {

                        value = JSON.stringify(value);

                        var offset = 0;
                        var i = 0;

                        while (offset < value.length) {

                            var length = Math.min(maxLength, value.length
                                            - offset);
                            var string = value.substring(offset, offset
                                            + length);

                            offset += length;

                            var key = getKey(name, i);

                            Browser.cookie(key, string);

                            i++;
                        }
                    }
                },

                contains: function (name) {

                    var value = Browser.cookie(name);

                    return Objects.isDefined(value) && value.length > 0;
                },

                remove: function (name) {

                    var i = 0;

                    while (true) {

                        var key = getKey(name, i);

                        var value = Browser.cookie(key);

                        if (value) {

                            Browser.cookie(key, null);

                        } else {

                            break;
                        }

                        i++;
                    }
                },

                clear: function () {

                }
            };
        }
    };

    /**
     * Look-up for for the content stored under the given property name
     *
     * @param {String}
     *            the name of the property we want
     *
     * @return {Any} the data stored under the given property name
     *
     * @member LocalStorage
     */
    LocalStorage.get = function (name) {

        /*
         * link to logged user if possible
         */
        if (LocalStorage.linkToUser && Browser.user) {
            name = Browser.user.getUsername() + ":" + name;
        }

        return api.get(name);
    };

    /**
     * Set/update the given value under the given name. The same can now be
     * retrieved via {@link LocalStorage#get()}
     *
     * @param name
     *            {String} the name of the property
     *
     * @param value
     *            {Any} the data to be stored
     */
    LocalStorage.set = function (name, value) {

        /*
         * link to logged user if possible
         */
        if (LocalStorage.linkToUser && Browser.user) {
            name = Browser.user.getUsername() + ":" + name;
        }

        return api.set(name, value);
    };

    /**
     * Verify if the local storage has a property of the given name
     *
     * @return {Boolean} true if exists, false otherwise
     */
    LocalStorage.contains = function (name) {

        /*
         * link to logged user if possible
         */
        if (LocalStorage.linkToUser && Browser.user) {
            name = Browser.user.getUsername() + ":" + name;
        }

        return api.contains(name);
    };

    /**
     * Discard the content of stored under the given property name
     *
     * @param {String}
     *            the name of the property being discarded
     */
    LocalStorage.remove = function (name) {

        /*
         * link to logged user if possible
         */
        if (LocalStorage.linkToUser && Browser.user) {
            name = Browser.user.getUsername() + ":" + name;
        }

        api.remove(name);
    };

    /**
     * Permanently discard all values currently loaded into the storage.
     */
    LocalStorage.clear = function () {

        api.clear();
    };

    /**
     * Look up for the storage type currently being used.
     *
     * @return {String} either "local" if using <code>localStorage</code> or
     *         <code>cookie</code> if localStorage is not available.
     */
    LocalStorage.getType = function () {

        return type;
    };

    /**
     * Alter the storage type utilizing from now-on the given storage type
     * discarding the previous storage being used.
     *
     * @param type
     *            {String} the new storage type to be used
     */
    LocalStorage.setType = function (type) {

        construct(type);
    };

    /**
     * Verify if currently using a local storage type
     *
     * @return {Boolean} true if currently using cookies a local storage, false
     *         otherwise
     */
    LocalStorage.isCookie = function () {

        return type === "cookie";
    };

    var isLocal = ("localStorage" in window && window.localStorage !== null);

    if (isLocal) {

        try {
            localStorage.setItem("test", "value");
            localStorage.removeItem("test");
        } catch (e) {
            isLocal = false;
        }
    }

    /*
     * construct loading the available storage type wrapper
     */
    construct(isLocal ? "local" : "cookie");
})();

/**
 * String utility class for the Orion Framework.
 *
 * @author Ivanir Joao Kreuzberg
 *
 * @since 1.0
 *
 * @class
 * @name Strings
 */
function Strings() {
}

/**
 * Tokenize the given String by camel case replacing upper case characters by
 * the given token.
 *
 * @param string
 *
 * @param token
 *
 * @return text
 */
Strings.tokenizeByCamelCase = function (string, token) {

    if (!string) {

        return string;
    }

    var result = [string.substring(0, 1)];

    for (var i = 1; i < string.length; i++) {

        var c = string.charAt(i).toUpperCase();

        if (c != " " && c == string.charAt(i)) {

            result.push(token);
            result.push(string.charAt(i).toLowerCase());

        } else {

            result.push(string.charAt(i));
        }
    }

    return result.join("");
};

/**
 * UN-Capitalize the first character of the given String
 *
 * @param value
 *            the String value being UN-capitalized
 *
 * @return UN-capitalized String
 *
 * @member Strings
 */
Strings.uncapitalize = function (value) {

    if (typeof value === "string" && value.length > 0) {

        return value.charAt(0).toLowerCase() + value.substring(1);
    }

    return value;
};

/**
 * Replace within the given String value, all occurrences of the existing value
 * with the given new String value.
 *
 * @param string
 *            {String} the String value being parsed
 *
 * @param oldValue
 *            {String} the existing value to be replaced
 *
 * @param newValue
 *            {String} the new value to be replaced
 *
 * @param regex
 *            {Boolean} flag that indicates if we should use regex 'g' to
 *            replace all or not. If you're replacing characters that may
 *            conflict with regex, you might not want to use this as true.
 *            Defaults to false
 *
 * @return formatted value containing the replaced values
 */
Strings.replaceAll = function (string, oldValue, newValue, regex) {

    if (regex !== true) {

        var result = string;
        var i = result.indexOf(oldValue);

        while (i >= 0) {

            result = result.replace(oldValue, newValue);

            i = result.indexOf(oldValue);
        }

        return result;
    }

    return string.replace(new RegExp(oldValue, "g"), newValue);
};

/**
 * Parse the given String value into a Date object instance
 *
 * @param value
 *            {String} the string date value
 *
 * @return {Date} the parsed date, null if given value is empty or null
 */
Strings.parseDate = function (value) {

    if (Object.prototype.toString.call(value) == '[object Date]') {
        return value;
    }

    if (!value) {
        return null;
    }

    if (!isNaN(value)) {

        return new Date(Number(value));
    }

    var string = value.replace(/\-/g, "\/");

    // TODO: this is just nuts. We should be using a date parsing utility
    string = string.replace("T", " ");

    var index = value.lastIndexOf(".");

    if (index > 0) {

        string = string.substring(0, index)

        var ms = parseInt(value.substring(index + 1));
        var date = new Date(string);

        date.setTime(date.getTime() + ms);

        return date;
    } else {

        return new Date(string);
    }
}

Strings.toCssClass = function (value) {

    if (value) {

        return Strings.uncapitalize(Strings.tokenizeByCamelCase(value, "-"));
    }

    return "";
};

/**
 * URL utility class for the Orion Framework.
 *
 * @author Ivanir Joao Kreuzberg
 *
 * @since 1.0
 *
 * @class
 * @name Strings
 */
function URLs() {
}

/**
 * Parse the given query string into a JavaScript hash object holding the query
 * string key -> value.
 *
 * @param query
 *            the HTTP URL/query string
 *
 * @param ignore
 *            indicates if we should ignore the query string question mark and
 *            simply replace the variables in it. Pass true if you are sure
 *            you're only providing the query string and not the complete url
 *
 * @return hash object containing the query string values
 */
URLs.fromQueryString = function (query, parseUrl) {

    if (query.indexOf("?") >= 0 && parseUrl !== false) {
        query = query.substring(query.indexOf("?"));
    }

    var result = {};

    if (query && query.indexOf("=") > 0) {

        query = unescape(query);

        query = Strings.replaceAll(query, "+", " ");

        var variables = query.split("&");

        for (var i = 0; i < variables.length; i++) {

            var variable = variables[i];
            var values = variable.split("=");
            var name = (values[0].indexOf("?") === 0) ? values[0].substring(1)
                            : values[0];
            var value = values[1];

            name = decodeURIComponent(name);
            value = decodeURIComponent(value);

            result[name] = value;
        }
    }

    return result;
};

/**
 * Array utility class
 *
 * @author Ivanir Joao Kreuzberg
 *
 * @since 1.0
 *
 * <ul class="import">
 * <li>import orion.reflect.Reflection;</li>
 * <li>import orion.utils.Prototype;</li>
 * </ul>
 *
 * @class
 * @name Arrays
 */
function Arrays() {
}

/**
 * Remove the given item from the given array
 *
 * @param array
 *            the array being manipulated
 *
 * @param value
 *            the value being removed
 */
Arrays.remove = function (array, value) {

    Arrays.removeAt(array, array.indexOf(value));
};

/**
 * Remove an item represented by the given <code>index</code>
 *
 * @param array
 *            the array being manipulated
 *
 * @param index
 *            the index representing the element being removed
 */
Arrays.removeAt = function (array, index) {

    array.splice(index, 1);
};

/**
 * Add an item to the given array within the given position
 *
 * @param array
 *            the array being manipulated
 *
 * @param item
 *            the item being added
 *
 * @param index
 *            the position of the item being added
 */
Arrays.addAt = function (array, item, index) {

    array.splice(index, 0, item);
};

/**
 * Move an item from one index position to another index position
 *
 * @param array
 *            the array being manipulated
 *
 * @param from
 *            the current index position
 *
 * @param to
 *            the new index position
 */
Arrays.moveAt = function (array, from, to) {

    var item = array[from];

    Arrays.removeAt(array, from);
    Arrays.addAt(array, item, to);
};

/**
 * Check if the given first array contains at least any of the elements from the
 * second array.
 *
 * @param a
 *            {Array} the first array
 *
 * @param b
 *            {Array} the second array
 *
 * return {Boolean} true if at least one element of b is in a, false otherwise
 */
Arrays.containsAny = function (a, b) {

    for (var i = 0; i < b.length; i++) {

        if (a.indexOf(b[i]) >= 0) {

            return true;
        }
    }

    return false;
};

/**
 * Move the given single element to a new position on this collection. *
 *
 * @param elements
 *            {Array} the elements being moved
 *
 * @param index
 *            {int} the new index for the moved element
 *
 * @return {Array} the updated array with the moved items
 */
Arrays.moveAll = function (array, values, index) {

    var position = index;

    Objects.each(values, function (i, value) {

        Arrays.remove(array, value);
    });

    Objects.each(values, function (i, value) {

        Arrays.addAt(array, value, position);

        position++;
    });

    return array;
};