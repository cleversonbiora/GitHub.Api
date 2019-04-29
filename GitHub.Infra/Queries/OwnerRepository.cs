using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Infra.Repositories
{
    public partial class OwnerRepository
    {
        private const string QuerySelectById = @"SELECT *
                                                    FROM [dbo].[Owner]
                                                    WHERE Id = @Id";
        private const string QueryUpdate = @"MERGE INTO [Owner] AS Target  
                                            USING (VALUES (@Login,@Id,@NodeId,@AvatarUrl,@Url,@HtmlUrl,@FollowersUrl,@FollowingUrl,@ReposUrl)) 
                                                   AS Source (Login,Id,NodeId,AvatarUrl,Url,HtmlUrl,FollowersUrl,FollowingUrl,ReposUrl)  
                                            ON Target.Id = Source.Id  
                                            WHEN MATCHED THEN  
                                            UPDATE SET Login=Source.Login,Id=Source.Id,NodeId=Source.NodeId,AvatarUrl=Source.AvatarUrl,Url=Source.Url,HtmlUrl=Source.HtmlUrl,FollowersUrl=Source.FollowersUrl,FollowingUrl=Source.FollowingUrl,ReposUrl=Source.ReposUrl
                                            WHEN NOT MATCHED BY TARGET THEN  
                                            INSERT (Login,Id,NodeId,AvatarUrl,Url,HtmlUrl,FollowersUrl,FollowingUrl,ReposUrl) VALUES (Login,Id,NodeId,AvatarUrl,Url,HtmlUrl,FollowersUrl,FollowingUrl,ReposUrl)  
                                            OUTPUT $action;  ";
    }
}
