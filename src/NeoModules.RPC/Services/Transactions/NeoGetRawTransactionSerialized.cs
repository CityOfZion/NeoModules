﻿using System;
using System.Threading.Tasks;
using NeoModules.JsonRpc.Client;

namespace NeoModules.RPC.Services.Transactions
{
    /// <Summary>
    ///     getrawtransaction    
    ///     Returns the corresponding transaction information, based on the specified hash value.
    /// 
    ///     Parameters
    ///     Txid: Transaction ID
    ///     Verbose: Optional, the default value of verbose is 0. When verbose is 0, the serialized information of the block is returned, represented by a hexadecimal string. 
    ///     If you need to get detailed information, you will need to use the SDK for deserialization. When verbose is 1, detailed information of the corresponding block in Json format string, is returned.
    /// 
    ///     Returns
    ///     Transaction object
    /// 
    ///     Example
    ///     Request
    ///     curl -X POST --data '{"jsonrpc":"2.0","method":"getrawtransaction","params":["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657"],"id":1}'
    ///
    ///     Result
    ///     {
    ///     "jsonrpc": "2.0",
    ///     "id": 1,
    ///     "result": "80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"
    ///     }
    /// </Summary>
    public class NeoGetRawTransactionSerialized : RpcRequestResponseHandler<string>
    {
        public NeoGetRawTransactionSerialized(IClient client) : base(client, ApiMethods.getrawtransaction.ToString())
        {
        }

        public Task<string> SendRequestAsync(string txId, object id = null)
        {
            if (txId == null) throw new ArgumentNullException(nameof(txId));
            return base.SendRequestAsync(id, txId, 0);
        }

        public RpcRequest BuildRequest(string txId, object id = null)
        {
            if (txId == null) throw new ArgumentNullException(nameof(txId));
            return base.BuildRequest(id, txId, 0);
        }
    }
}
