using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System;

namespace ITFCode.Core.Web
{
    /// <summary>
    /// HTTP Headers >> https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers
    /// </summary>
    public static class HttpHeaders
    {
        #region Authentication

        /// <summary>
        /// Defines the authentication method that should be used to access a resource.
        /// </summary>
        public const string WWW_Authenticate = "WWW-Authenticate";
        /// <summary>
        /// Contains the credentials to authenticate a user-agent with a server.
        /// </summary>
        public const string Authorization = "Authorization";
        /// <summary>
        /// Defines the authentication method that should be used to access a resource behind a proxy server.
        /// </summary>
        public const string PROXY_AUTHENTICATE = "Proxy-Authenticate";
        /// <summary>
        /// Contains the credentials to authenticate a user agent with a proxy server
        /// </summary>
        public const string Proxy_Authorization = "Proxy-Authorization";

        #endregion

        #region Caching

        /// <summary>
        /// The time, in seconds, that the object has been in a proxy cache
        /// </summary>
        public const string Age = "Age";
        /// <summary>
        /// Directives for caching mechanisms in both requests and responses
        /// </summary>
        public const string Cache_Control = "Cache-Control";
        /// <summary>
        /// Clears browsing data (e.g. cookies, storage, cache) associated with the requesting website
        /// </summary>
        public const string Clear_Site_Data = "Clear-Site-Data";
        /// <summary>
        /// The date/time after which the response is considered stale
        /// </summary>
        public const string Expires = "Expires";
        /// <summary>
        /// Implementation-specific header that may have various effects anywhere along the request-response chain. 
        /// Used for backwards compatibility with HTTP/1.0 caches where the Cache-Control header is not yet present
        /// </summary>
        public const string PRAGMA = "Pragma";
        /// <summary>
        /// General warning information about possible problems
        /// </summary>
        public const string Warning = "Warning";

        #endregion

        #region Client hints

        /// <summary>
        /// Servers can advertise support for Client Hints using the Accept-CH header field or an equivalent HTML <meta> element with http-equiv attribute
        /// </summary>
        public const string Accept_CH = "Accept-CH";
        /// <summary>
        /// Servers can ask the client to remember the set of Client Hints that the server supports for a specified period of time, 
        /// to enable delivery of Client Hints on subsequent requests to the server's origin
        /// </summary>
        public const string Accept_CH_Lifetime = "Accept-CH-Lifetime";
        /// <summary>
        /// Servers use Critical-CH along with Accept-CH to specify that accepted client hints are also critical client hints
        /// </summary>
        public const string Critical_CH = "Critical-CH";

        #endregion

        #region  User agent client hints

        /// <summary>
        /// User agent's branding and version (Experimental)
        /// </summary>
        public const string Sec_CH_UA = "Sec-CH-UA";
        /// <summary>
        /// User agent's underlying platform architecture (Experimental)
        /// </summary>
        public const string Sec_CH_UA_Arch = "Sec-CH-UA-Arch";
        /// <summary>
        /// User agent's underlying CPU architecture bitness (for example "64" bit) (Experimental)
        /// </summary>
        public const string Sec_CH_UA_Bitness = "Sec-CH-UA-Bitness";
        /// <summary>
        /// User agent's full semantic version string (Experimental)
        /// </summary>
        public const string Sec_CH_UA_Full_Version = "Sec-CH-UA-Full-Version";
        /// <summary>
        /// Full version for each brand in the user agent's brand list (Experimental)
        /// </summary>
        public const string Sec_CH_UA_Full_Version_List = "Sec-CH-UA-Full-Version-List";
        /// <summary>
        /// User agent is running on a mobile device or, more generally, prefers a "mobile" user experience(Experimental)
        /// </summary>
        public const string Sec_CH_UA_Mobile = "Sec-CH-UA-Mobile";
        /// <summary>
        /// User agent's device model (Experimental) 
        /// </summary>
        public const string Sec_CH_UA_Model = "Sec-CH-UA-Model";
        /// <summary>
        /// User agent's underlying operation system/platform (Experimental) 
        /// </summary>
        public const string Sec_CH_UA_Platform = "Sec-CH-UA-Platform";
        /// <summary>
        /// User agent's underlying operation system version (Experimental)
        /// </summary>
        public const string Sec_CH_UA_Platform_Version = "Sec-CH-UA-Platform-Version";
        /// <summary>
        /// User's preference of dark or light color scheme (Experimental)
        /// </summary>
        public const string Sec_CH_UA_Prefers_Color_Scheme = "Sec-CH-UA-Prefers-Color-Scheme";
        /// <summary>
        /// User's preference to see fewer animations and content layout shifts (Experimental)
        /// </summary>
        public const string Sec_CH_UA_Prefers_Reduced_Motion = "Sec-CH-UA-Prefers-Reduced-Motion";

        #endregion

        #region Device client hints

        /// <summary>
        /// Response header used to confirm the image device to pixel ratio in requests where the DPR client hint was used to select an image resource (Deprecated)
        /// </summary>
        public const string Content_DPR = "Content-DPR";
        /// <summary>
        /// Approximate amount of available client RAM memory.This is part of the Device Memory API (Deprecated)
        /// </summary>
        public const string Device_Memory = "Device-Memory";
        /// <summary>
        /// Client device pixel ratio (DPR), which is the number of physical device pixels corresponding to every CSS pixel (Deprecated)
        /// </summary>
        public const string DPR = "DPR";
        /// <summary>
        /// A number that indicates the layout viewport width in CSS pixels.The provided pixel value is a number rounded to the smallest following integer (i.e.ceiling value) (Deprecated)
        /// </summary>
        public const string Viewport_Width = "Viewport-Width";
        /// <summary>
        /// A number that indicates the desired resource width in physical pixels(i.e.intrinsic size of an image) (Deprecated)
        /// </summary>
        public const string Width = "Width";

        #endregion

        #region Conditionals

        /// <summary>
        /// The last modification date of the resource, used to compare several versions of the same resource. 
        /// It is less accurate than ETag, but easier to calculate in some environments. Conditional requests 
        /// using If-Modified-Since and If-Unmodified-Since use this value to change the behavior of the request
        /// </summary>
        public const string LastModified = "Last-Modified";
        /// <summary>
        /// A unique string identifying the version of the resource. Conditional requests using If-Match 
        /// and If-None-Match use this value to change the behavior of the request
        /// </summary>
        public const string ETag = "ETag";
        /// <summary>
        /// Makes the request conditional, and applies the method only if the stored resource matches one of the given ETags
        /// </summary>
        public const string If_Match = "If-Match";
        /// <summary>
        /// Makes the request conditional, and applies the method only if the stored resource doesn't match any of the given ETags. 
        /// This is used to update caches (for safe requests), or to prevent uploading a new resource when one already exists
        /// </summary>
        public const string If_None_Match = "If-None-Match";
        /// <summary>
        /// Makes the request conditional, and expects the resource to be transmitted only if it has been modified after the given date. 
        /// This is used to transmit data only when the cache is out of date
        /// </summary>
        public const string If_Modified_Since = "If-Modified-Since";
        /// <summary>
        /// Makes the request conditional, and expects the resource to be transmitted only if it has not been modified after the given date. 
        /// This ensures the coherence of a new fragment of a specific range with previous ones, or to implement an optimistic concurrency 
        /// control system when modifying existing documents
        /// </summary>
        public const string If_Unmodified_Since = "If-Unmodified-Since";
        /// <summary>
        /// Determines how to match request headers to decide whether a cached response can be used rather than requesting 
        /// a fresh one from the origin server
        /// </summary>
        public const string Vary = "Vary";

        #endregion

        #region Connection management

        /// <summary>
        /// Controls whether the network connection stays open after the current transaction finishes
        /// </summary>
        public const string Connection = "Connection";
        /// <summary>
        /// Controls how long a persistent connection should stay open.
        /// </summary>
        public const string KeepAlive = "Keep-Alive";

        #endregion

        #region Content negotiation

        /// <summary>
        /// Informs the server about the types of data that can be sent back
        /// </summary>
        public const string Accept = "Accept";
        /// <summary>
        /// The encoding algorithm, usually a compression algorithm, that can be used on the resource sent back
        /// </summary>
        public const string Accept_Encoding = "Accept-Encoding";
        /// <summary>
        /// Informs the server about the human language the server is expected to send back. 
        /// This is a hint and is not necessarily under the full control of the user: 
        /// the server should always pay attention not to override an explicit user choice (like selecting a language from a dropdown)
        /// </summary>
        public const string Accept_Language = "Accept-Language";

        #endregion

        #region Controls

        /// <summary>
        /// Indicates expectations that need to be fulfilled by the server to properly handle the request.
        /// </summary>
        public const string Expect = "Expect";
        /// <summary>
        /// When using TRACE, indicates the maximum number of hops the request can do before being reflected to the sender
        /// </summary>
        public const string Max_Forwards = "Max-Forwards";

        #endregion

        #region Cookies

        /// <summary>
        /// Contains stored HTTP cookies previously sent by the server with the Set-Cookie header
        /// </summary>
        public const string Cookie = "Cookie";
        /// <summary>
        /// Send cookies from the server to the user-agent
        /// </summary>
        public const string Set_Cookie = "Set-Cookie";

        #endregion

        #region CORS

        /// <summary>
        /// Indicates whether the response can be shared
        /// </summary>
        public const string Access_Control_Allow_Origin = "Access-Control-Allow-Origin";
        /// <summary>
        /// Indicates whether the response to the request can be exposed when the credentials flag is true
        /// </summary>
        public const string Access_Control_Allow_Credentials = "Access-Control-Allow-Credentials";
        /// <summary>
        /// Used in response to a preflight request to indicate which HTTP headers can be used when making the actual request
        /// </summary>
        public const string Access_Control_Allow_Headers = "Access-Control-Allow-Headers";
        /// <summary>
        /// Specifies the methods allowed when accessing the resource in response to a preflight request
        /// </summary>
        public const string Access_Control_Allow_Methods = "Access-Control-Allow-Methods";
        /// <summary>
        /// Indicates which headers can be exposed as part of the response by listing their names
        /// </summary>
        public const string Access_Control_Expose_Headers = "Access-Control-Expose-Headers";
        /// <summary>
        /// Indicates how long the results of a preflight request can be cached
        /// </summary>
        public const string Access_Control_Max_Age = "Access-Control-Max-Age";
        /// <summary>
        /// Used when issuing a preflight request to let the server know which HTTP headers will be used when the actual request is made
        /// </summary>
        public const string Access_Control_Request_Headers = "Access-Control-Request-Headers";
        /// <summary>
        /// Used when issuing a preflight request to let the server know which HTTP method will be used when the actual request is made
        /// </summary>
        public const string Access_Control_Request_Method = "Access-Control-Request-Method";
        /// <summary>
        /// Indicates where a fetch originates from
        /// </summary>
        public const string Origin = "Origin";
        /// <summary>
        /// Specifies origins that are allowed to see values of attributes retrieved via features of the Resource Timing API, 
        /// which would otherwise be reported as zero due to cross-origin restrictions
        /// </summary>
        public const string Timing_Allow_Origin = "Timing-Allow-Origin";

        #endregion

        #region Downloads

        /// <summary>
        /// Indicates if the resource transmitted should be displayed inline(default behavior without the header), 
        /// or if it should be handled like a download and the browser should present a "Save As" dialog
        /// </summary>
        public const string Content_Disposition = "Content-Disposition";

        #endregion

        #region Message body information

        /// <summary>
        /// The size of the resource, in decimal number of bytes
        /// </summary>
        public const string Content_Length = "Content-Length";
        /// <summary>
        /// Indicates the media type of the resource
        /// </summary>
        public const string Content_Type = "Content-Type";
        /// <summary>
        /// Used to specify the compression algorithm
        /// </summary>
        public const string Content_Encoding = "Content-Encoding";
        /// <summary>
        /// Describes the human language(s) intended for the audience, so that it allows 
        /// a user to differentiate according to the users' own preferred language
        /// </summary>
        public const string Content_Language = "Content-Language";
        /// <summary>
        /// Indicates an alternate location for the returned data
        /// </summary>
        public const string Content_Location = "Content-Location";

        #endregion

        #region Proxies

        /// <summary>
        /// Contains information from the client-facing side of proxy servers that is altered or lost when a proxy is involved in the path of the request
        /// </summary>
        public const string Forwarded = "Forwarded";
        /// <summary>
        /// Identifies the originating IP addresses of a client connecting to a web server through an HTTP proxy or a load balancer (Non-Standard)
        /// </summary>
        public const string X_Forwarded_For = "X-Forwarded-For";
        /// <summary>
        /// Identifies the original host requested that a client used to connect to your proxy or load balancer (Non-Standard)
        /// </summary>
        public const string X_Forwarded_Host = "X-Forwarded-Host";
        /// <summary>
        /// Identifies the protocol (HTTP or HTTPS) that a client used to connect to your proxy or load balancer (Non-Standard)
        /// </summary>
        public const string X_Forwarded_Proto = "X-Forwarded-Proto";
        /// <summary>
        /// Added by proxies, both forward and reverse proxies, and can appear in the request headers and the response headers
        /// </summary>
        public const string Via = "Via";

        #endregion

        #region Redirects

        /// <summary>
        /// Indicates the URL to redirect a page to
        /// </summary>
        public const string Location = "Location";
        /// <summary>
        /// Directs the browser to reload the page or redirect to another. Takes the same value as the meta element with http-equiv="refresh"
        /// </summary>
        public const string Refresh = "Refresh";

        #endregion

        #region Request context

        /// <summary>
        /// Contains an Internet email address for a human user who controls the requesting user agent.
        /// </summary>
        public const string From = "From";
        /// <summary>
        /// Specifies the domain name of the server (for virtual hosting), and (optionally) the TCP port number on which the server is listening
        /// </summary>
        public const string Host = "Host";
        /// <summary>
        /// The address of the previous web page from which a link to the currently requested page was followed
        /// </summary>
        public const string Referer = "Referer";
        /// <summary>
        /// Governs which referrer information sent in the Referer header should be included with requests made
        /// </summary>
        public const string Referrer_Policy = "Referrer-Policy";
        /// <summary>
        /// Contains a characteristic string that allows the network protocol peers to identify the application type, 
        /// operating system, software vendor or software version of the requesting software user agent
        /// </summary>
        public const string User_Agent = "User-Agent";

        #endregion

        #region Response context

        /// <summary>
        /// Lists the set of HTTP request methods supported by a resource
        /// </summary>
        public const string Allow = "Allow";
        /// <summary>
        /// Contains information about the software used by the origin server to handle the request
        /// </summary>
        public const string Server = "Server";

        #endregion

        #region Range requests

        /// <summary>
        /// Indicates if the server supports range requests, and if so in which unit the range can be expressed
        /// </summary>
        public const string Accept_Ranges = "Accept-Ranges";
        /// <summary>
        /// Indicates the part of a document that the server should return
        /// </summary>
        public const string Range = "Range";
        /// <summary>
        /// Creates a conditional range request that is only fulfilled if the given etag or date matches the remote resource. 
        /// Used to prevent downloading two ranges from incompatible version of the resource
        /// </summary>
        public const string If_Range = "If-Range";
        /// <summary>
        /// Indicates where in a full body message a partial message belongs
        /// </summary>
        public const string Content_Range = "Content-Range";

        #endregion

        #region Security

        /// <summary>
        /// Allows a server to declare an embedder policy for a given document
        /// </summary>
        public const string Cross_Origin_Embedder_Policy = "Cross-Origin-Embedder-Policy";
        /// <summary>
        /// Prevents other domains from opening/controlling a window
        /// </summary>
        public const string Cross_Origin_Opener_Policy = "Cross-Origin-Opener-Policy";
        /// <summary>
        /// Prevents other domains from reading the response of the resources to which this header is applied
        /// </summary>
        public const string Cross_Origin_Resource_Policy = "Cross-Origin-Resource-Policy";
        /// <summary>
        /// Controls resources the user agent is allowed to load for a given page
        /// </summary>
        public const string Content_Security_Policy = "Content-Security-Policy";
        /// <summary>
        /// Allows web developers to experiment with policies by monitoring, but not enforcing, their effects. 
        /// These violation reports consist of JSON documents sent via an HTTP POST request to the specified URI
        /// </summary>
        public const string Content_Security_Policy_Report_Only = "Content-Security-Policy-Report-Only";
        /// <summary>
        /// Allows sites to opt in to reporting and/or enforcement of Certificate Transparency requirements, 
        /// which prevents the use of misissued certificates for that site from going unnoticed. 
        /// When a site enables the Expect-CT header, they are requesting that 
        /// Chrome check that any certificate for that site appears in public CT logs
        /// </summary>
        public const string Expect_CT = "Expect-CT";
        /// <summary>
        /// Provides a mechanism to allow web applications to isolate their origins
        /// </summary>
        public const string Origin_Isolation = "Origin-Isolation";
        /// <summary>
        /// Provides a mechanism to allow and deny the use of browser features in a website's own frame, and in <iframe>s that it embeds
        /// </summary>
        public const string Permissions_Policy = "Permissions-Policy";
        /// <summary>
        /// Force communication using HTTPS instead of HTTP
        /// </summary>
        public const string Strict_Transport_Security = "Strict-Transport-Security";
        /// <summary>
        /// Sends a signal to the server expressing the client's preference for an encrypted and authenticated response, 
        /// and that it can successfully handle the upgrade-insecure-requests directive
        /// </summary>
        public const string Upgrade_Insecure_Requests = "Upgrade-Insecure-Requests";
        /// <summary>
        /// Disables MIME sniffing and forces browser to use the type given in Content-Type
        /// </summary>
        public const string X_Content_Type_Options = "X-Content-Type-Options";
        /// <summary>
        /// Indicates whether a browser should be allowed to render a page in a <frame>, <iframe>, <embed> or <object>
        /// </summary>
        public const string X_Frame_Options = "X-Frame-Options";
        /// <summary>
        /// Specifies if a cross-domain policy file (crossdomain.xml) is allowed. The file may define a policy to grant clients, 
        /// such as Adobe's Flash Player (now obsolete), Adobe Acrobat, Microsoft Silverlight (now obsolete), 
        /// or Apache Flex, permission to handle data across domains that would otherwise be restricted due to the Same-Origin Policy. 
        /// See the Cross-domain Policy File Specification for more information
        /// </summary>
        public const string X_Permitted_Cross_Domain_Policies = "X-Permitted-Cross-Domain-Policies";
        /// <summary>
        /// May be set by hosting environments or other frameworks and contains information about them while not providing 
        /// any usefulness to the application or its visitors. Unset this header to avoid exposing potential vulnerabilities
        /// </summary>
        public const string X_Powered_By = "X-Powered-By";
        /// <summary>
        /// Enables cross-site scripting filtering
        /// </summary>
        public const string X_XSS_Protection = "X-XSS-Protection";

        #endregion

        #region Fetch metadata request headers

        /// <summary>
        /// Indicates the relationship between a request initiator's origin and its target's origin. 
        /// It is a Structured Header whose value is a token with possible values cross-site, same-origin, same-site, and none.
        /// </summary>
        public const string Sec_Fetch_Site = "Sec-Fetch-Site";
        /// <summary>
        /// Indicates the request's mode to a server. It is a Structured Header whose value is a token with possible 
        /// values cors, navigate, no-cors, same-origin, and websocket
        /// </summary>
        public const string Sec_Fetch_Mode = "Sec-Fetch-Mode";
        /// <summary>
        /// Indicates whether or not a navigation request was triggered by user activation. 
        /// It is a Structured Header whose value is a boolean so possible values are ?0 for false and ?1 for true
        /// </summary>
        public const string Sec_Fetch_User = "Sec-Fetch-User";
        /// <summary>
        /// Indicates the request's destination. It is a Structured Header whose value is a token with possible values audio, 
        /// audioworklet, document, embed, empty, font, image, manifest, object, paintworklet, report, script, serviceworker, 
        /// sharedworker, style, track, video, worker, and xslt
        /// </summary>
        public const string Sec_Fetch_Dest = "Sec-Fetch-Dest";
        /// <summary>
        /// Indicates the purpose of the request, when the purpose is something other than immediate use by the user-agent. 
        /// The header currently has one possible value, prefetch, which indicates that the resource 
        /// is being fetched preemptively for a possible future navigation (Experimental)
        /// </summary>
        public const string Sec_Purpose = "Sec-Purpose";
        /// <summary>
        /// A request header sent in preemptive request to fetch() a resource during service worker boot. 
        /// The value, which is set with NavigationPreloadManager.setHeaderValue(), can be used to inform 
        /// a server that a different resource should be returned than in a normal fetch() operation
        /// </summary>
        public const string Service_Worker_Navigation_Preload = "Service-Worker-Navigation-Preload";

        #endregion

        #region Server-sent events

        /// <summary>
        /// TBD
        /// </summary>
        public const string Last_Event_ID = "Last-Event-ID";
        /// <summary>
        /// Defines a mechanism that enables developers to declare a network error reporting policy
        /// </summary>
        public const string NEL = "NEL";
        /// <summary>
        /// TBD
        /// </summary>
        public const string Ping_From = "Ping-From";
        /// <summary>
        /// TBD
        /// </summary>
        public const string Ping_To = "Ping-To";
        /// <summary>
        /// Used to specify a server endpoint for the browser to send warning and error reports to
        /// </summary>
        public const string Report_To = "Report-To";

        #endregion

        #region Transfer coding

        /// <summary>
        /// Specifies the form of encoding used to safely transfer the resource to the user
        /// </summary>
        public const string Transfer_Encoding = "Transfer-Encoding";
        /// <summary>
        /// Specifies the transfer encodings the user agent is willing to accept
        /// </summary>
        public const string TE = "TE";
        /// <summary>
        /// Allows the sender to include additional fields at the end of chunked message
        /// </summary>
        public const string Trailer = "Trailer";

        #endregion

        #region WebSockets

        #endregion



        public const string Accept_Charset = "Accept-Charset";

        public const string Accept_Patch = "Accept-Patch";
        public const string Accept_Post = "Accept-Post";
        public const string Alt_Svc = "Alt-Svc";

        public const string Cookie2 = "Cookie2";

        public const string Date = "Date";
        public const string Digest = "Digest";
        public const string DNT = "DNT";

        public const string Early_Data = "Early-Data";

        public const string Feature_Policy = "Feature-Policy";


        public const string Index = "Index";


        public const string Large_Allocation = "Large-Allocation";
        public const string Link = "Link";


        public const string Public_Key_Pins_Report_Only = "Public-Key-Pins-Report-Only";
        public const string Public_Key_Pins = "Public-Key-Pins";

        public const string Retry_After = "Retry-After";

        public const string Save_Data = "Save-Data";
        

        public const string Sec_WebSocket_Accept = "Sec-WebSocket-Accept";
        public const string Server_Timing = "Server-Timing";
        public const string Set_Cookie2 = "Set-Cookie2";
        public const string Source_Map = "SourceMap";

        public const string Tk = "Tk";

        public const string Upgrade = "Upgrade";


        /// <summary>
        /// 
        /// </summary>
        public const string Want_Digest = "Want-Digest";

        public const string X_DNS_Prefetch_Control = "X-DNS-Prefetch-Control";
    }
}