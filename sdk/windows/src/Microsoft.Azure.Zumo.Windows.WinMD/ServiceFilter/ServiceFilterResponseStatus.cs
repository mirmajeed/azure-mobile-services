﻿// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;

namespace Microsoft.WindowsAzure.MobileServices
{
    /// <summary>
    /// Defines status codes for responses in a service filter to indicate
    /// reasons for connection failures.
    /// </summary>
    public enum ServiceFilterResponseStatus
    {
        /// <summary>
        /// No error was encountered.
        /// </summary>
        Success = 0,

        /// <summary>
        /// The name resolver service could not resolve the host name.
        /// </summary>
        NameResolutionFailure = 1,

        /// <summary>
        /// The remote service point could not be contacted at the transport
        /// level.
        /// </summary>
        ConnectFailure = 2,

        /// <summary>
        /// A complete response was not received from the remote server.
        /// </summary>
        ReceiveFailure = 3,

        /// <summary>
        /// A complete request could not be sent to the remote server.
        /// </summary>
        SendFailure = 4,

        /// <summary>
        /// The request was a piplined request and the connection was closed
        /// before the response was received.
        /// </summary>
        PipelineFailure = 5,

        /// <summary>
        /// The request was canceled or an unclassifiable error occurred. This
        /// is the default value for ErrorStatus.
        /// </summary>
        RequestCanceled = 6,

        /// <summary>
        /// The response received from the server was complete but indicated a
        /// protocol-level error. For example, an HTTP protocol error such as
        /// 401 Access Denied would use this status.
        /// </summary>
        ProtocolError = 7,

        /// <summary>
        /// The connection was prematurely closed. 
        /// </summary>
        ConnectionClosed = 8,

        /// <summary>
        /// A server certificate could not be validated.
        /// </summary>
        TrustFailure = 9,

        /// <summary>
        /// An error occurred while establishing a connection using SSL.
        /// </summary>
        SecureChannelFailure = 10,

        /// <summary>
        /// The server response was not a valid HTTP response. 
        /// </summary>
        ServerProtocolViolation = 11,

        /// <summary>
        /// The connection for a request that specifies the Keep-alive header
        /// was closed unexpectedly.
        /// </summary>
        KeepAliveFailure = 12,

        /// <summary>
        /// An internal asynchronous request is pending.
        /// </summary>
        Pending = 13,

        /// <summary>
        /// No response was received during the time-out period for a request.
        /// </summary>
        Timeout = 14,

        /// <summary>
        /// The name resolver service could not resolve the proxy host name.
        /// </summary>
        ProxyNameResolutionFailure = 15,

        /// <summary>
        /// An exception of unknown type has occurred.
        /// </summary>
        UnknownError = 16,

        /// <summary>
        /// A message was received that exceeded the specified limit when
        /// sending a request or receiving a response from the server.
        /// </summary>
        MessageLengthLimitExceeded = 17,

        /// <summary>
        /// The specified cache entry was not found. 
        /// </summary>
        CacheEntryNotFound = 18,

        /// <summary>
        /// The request was not permitted by the cache policy. In general, this
        /// occurs when a request is not cacheable and the effective policy
        /// prohibits sending the request to the server. You might receive this
        /// status if a request method implies the presence of a request body,
        /// a request method requires direct interaction with the server, or a
        /// request contains a conditional header. 
        /// </summary>
        RequestProhibitedByCachePolicy = 19,

        /// <summary>
        /// This request was not permitted by the proxy.
        /// </summary>
        RequestProhibitedByProxy = 20
    }
}
