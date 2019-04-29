create table Owner(
        Login varchar(500),
        Id int,
        NodeId varchar(500),
        AvatarUrl varchar(500),
        Url varchar(500),
        HtmlUrl varchar(500),
        FollowersUrl varchar(500),
        FollowingUrl varchar(500),
        ReposUrl varchar(500)
    )
	
create table Repository(
        Id int,
        NodeId varchar(500),
        Name varchar(500),
        FullName varchar(500),
        Private bit,
        OwnerId int,
        HtmlUrl varchar(500),
        Description varchar(500),
        Fork bit,
        Url varchar(500)
)