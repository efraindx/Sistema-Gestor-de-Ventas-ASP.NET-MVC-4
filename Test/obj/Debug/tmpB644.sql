CREATE TABLE [dbo].[UserProfile] (
    [FirstName] [nvarchar](128) NOT NULL,
    [Email] [nvarchar](max),
    [UserId] [int] NOT NULL,
    [UserName] [nvarchar](max)
)
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](255) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId])
)
BEGIN TRY
    EXEC sp_MS_marksystemobject 'dbo.__MigrationHistory'
END TRY
BEGIN CATCH
END CATCH
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201310100150531_InitialMigrations_AutomaticMigration', 0x1F8B0800000000000400D557CD72DB3610BE77A6EFC0E1293D44B09D1C5C0F958C23DB1D4D2B3B133AB9AFC8A58C297E5800F448CFD6431FA9AFD005FF455A7F4E2EBD91E0EEB7DF2EF6C382FFFEFD4FF4712D45F08CC672ADA6E1F9E42C0C50253AE56A350D0B97BDBD0C3F7EF8F9A7E83695EBE05B63F7CEDB91A7B2D3F0C9B9FC8A319B3CA1043B913C31DAEACC4D122D19A49A5D9C9DFDCACECF191244485841107D2994E312CB177A9D699560EE0A100B9DA2B0F53A7D894BD4E01E24DA1C129C868F68DDA4320B836BC18128C428B230C8DF5F7DB5183BA3D52ACEC171108F9B1CE97B06C2624DF82A7F7F2CE7B30BCF998152DA119C56AFCA396CB3A17C6E296FB7F1B4CA9CA62131369F8DCEB8C0BE2199FE8E9BAD055A22C31C8DDB7CC1AC76BFE3C63AFF18066CDB9D0DFD5BEFB1ABE743557486763D0CEEF81AD33F50ADDC535BBA05AC9B95F38BCB30F8AA383509393953D0E7FB4208580A6CED692F62A70DFE860A0D384C3F837368A875E629963518111ED0BB95C0C589D4E8710FB5EA7D7F54BF1DF3B4093B57EEDDC50BD91DC678455D4F251FB1AE99C62D469272C0A9F83D52D62FE2DA0D1AAD7288D18D5B9224D605A97436E977EC8B84DAD09D8C59A5E346EF6C87E0A305E439D5AA7700D42B415CA97FF6363E5D84B2C260897D418B2DDB3612F52DAC70F0954213D3523337E060097EF766A91C991D53E826D40BF51E4ABE2B7FE3E49F2BC7DE5138D9798EF4AB78478949925F9923B674F69C42B57F9C8000B3FB009969514875E048DA8755ABBD8F532F1D8FD168B70FD2AC9D86324EAA5B1D23456C50DEE11EB2D1260E8EEA6163EC13D5D0A48DDE8A6B20A2A86EE8C3A375D4E195491850899E79EABB3BDE588772E20D26F15F622638E5DB192C40F18CBAF251FF8974D693002F0743FA150394599B8AFFCD1455CF60922730E3997970209E3867B6266413F68D84F52FDF37F5B8DFD1EF9C7927D0396D8E8D4FE1A387D9A1595675FB344C979AD2A8E8FE886137D65FC4FA17E0E8062D5F7510FE3AAC30F117CE0EB4B199AB4C37B5A72CFB8C1A93C1D62CD0414AC5BA368E679038FA9CA0B5E595E41B88A2ECA425A673F550B8BC70D7D6A25C8AAD0B5AC4F6C72F27FA36E7E821F76FF647A4403439A5800FEA53C145DAF2BE1BB7E62E08DF37B5F688155DC9086EB56991EEB53A12A82EDF0DE6A8BC721F51E682C0EC838AE11977733B5CC3ED8A45371C5606A4AD313A7FFF3FC6FC0FD987FF00692474F4C20D0000, '5.0.0.net45')
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201310100150531_InitialMigrations', 0x1F8B0800000000000400CD57CD72D33010BE33C33B787C8203515B38948E0353D296C9405A0617EE1B7B9D6AD08F91E44EF26C1C78245E8155FC1B3B4DDAD203374BDA5D7DFB693FADFCE7D7EFE8FD528AE0168DE55A8DC3C3D14118A04A74CAD5621C162E7B751CBE7FF7FC59749ECA65F0BDB67BEDEDC853D97178E35C7EC2984D6E50821D499E186D75E64689960C52CD8E0E0EDEB2C343861422A45841107D2D94E312D7031A4EB44A30770588994E51D86A9E56E275D4E01224DA1C121C87D768DDA8340B8353C18120C428B230C8DF9C7CB3183BA3D522CEC17110D7AB1C693D0361B1027C92BFB92FE683238F998152DA5138AD1E9573D86443F99C53DE6EE561AD731A8784D87C313AE302BB8664FA09571B13344586391AB7FA8A59E57E2E818B30609BAEACEFDB786EBA791CC49E3374DA6170C197987E46B570370D653358D6338747C761F04D712A0E7272A6A0E5CB4208980B6CECE90C62A70D7E4485061CA65FC039345432D314D7B90FC0F6A07942A6698D6DAADCEBA32DFBEC8FE1BF1E98217DEEC8B01C77378E587B9CC343A6A276C089860E28EB2771E97A475D3AC4E886454145DE6E5256FAA85B335B01355BB74262A5926AC5B13B2417CD20CF89AB8E04AB99202EF53779153F5C06B28CC112BB450D0DDA6627AA2058606F95B626A417DC5877060EE6E04F6F92CA81D97D88AEB7DAC2775F742DFDB593FF2E1D3B97D1E84E257759BCA0C42409619D23367076DC03957F9C8000B35DC6132D0AA9765C08BB62D47AEB06A9E71E16A5545C3F4E393B8C14B11E257DDED980F8DE25D73FCC5D42E89B34BB3782E8157E5415E1FE8634A8CAD2240C88A25B9EFA8A8C57D6A11C798351FC534C04A77C5B8319289E51255DEB1F48372589E6B8D7DA1ED17698B5A9F8EF7B8FBA0593DC8019769ABD6DE4113DA1ED2BDCF3FF8F5DA5C6FE42C2F2E553768AE13D77EF76B1AF5B94B5390ED3B9A6344AB84FD14E866A8958F791179DA1E58B36847FF2294CFCA3AA0D5ADB4C55A66BEE29CB2EA2DAA477343374901259A7C6F10C1247CB095ABB6EFADF4114EBB29B633A555785CB0B776A2DCAB9D8788C446CF7FEEB9EB98939BACAFDC83E450A0493530A78A53E145CA40DEE8B6169DE15C2D74DA51842458F1E0AB75835912EB5BA67A08ABE33CC5179BD5DA3CC0505B3572A865BBC1BDB7E0E37198BCE382C0C485BC568FDFD3F07F33F1DEFFE02259F91ACA60C0000, '5.0.0.net45')
ALTER TABLE [dbo].[UserProfile] ADD [FirstName] [nvarchar](128) NOT NULL DEFAULT ''
ALTER TABLE [dbo].[UserProfile] ALTER COLUMN [Email] [nvarchar](max)
ALTER TABLE [dbo].[UserProfile] ADD CONSTRAINT [PK_dbo.UserProfile] PRIMARY KEY ([FirstName])
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201310100152488_AutomaticMigration', 0x1F8B0800000000000400D557CD72DB3610BE77A6EFC0E1293D44B09D1C5C0F958C23DB1D4D2B3B133AB9AFC8A58C297E5800F448CFD6431FA9AFD005FF455A7F4E2EBD91E0EEB7DF2EF6C382FFFEFD4FF4712D45F08CC672ADA6E1F9E42C0C50253AE56A350D0B97BDBD0C3F7EF8F9A7E83695EBE05B63F7CEDB91A7B2D3F0C9B9FC8A319B3CA1043B913C31DAEACC4D122D19A49A5D9C9DFDCACECF191244485841107D2994E312CB177A9D699560EE0A100B9DA2B0F53A7D894BD4E01E24DA1C129C868F68DDA4320B836BC18128C428B230C8DF5F7DB5183BA3D52ACEC171108F9B1CE97B06C2624DF82A7F7F2CE7B30BCF998152DA119C56AFCA396CB3A17C6E296FB7F1B4CA9CA62131369F8DCEB8C0BE2199FE8E9BAD055A22C31C8DDB7CC1AC76BFE3C63AFF18066CDB9D0DFD5BEFB1ABE743557486763D0CEEF81AD33F50ADDC535BBA05AC9B95F38BCB30F8AA383509393953D0E7FB4208580A6CED692F62A70DFE860A0D384C3F837368A875E629963518111ED0BB95C0C589D4E8710FB5EA7D7F54BF1DF3B4093B57EEDDC50BD91DC678455D4F251FB1AE99C62D469272C0A9F83D52D62FE2DA0D1AAD7288D18D5B9224D605A97436E977EC8B84DAD09D8C59A5E346EF6C87E0A305E439D5AA7700D42B415CA97FF6363E5D84B2C260897D418B2DDB3612F52DAC70F0954213D3523337E060097EF766A91C991D53E826D40BF51E4ABE2B7FE3E49F2BC7DE5138D9798EF4AB78478949925F9923B674F69C42B57F9C8000B3FB009969514875E048DA8755ABBD8F532F1D8FD168B70FD2AC9D86324EAA5B1D23456C50DEE11EB2D1260E8EEA6163EC13D5D0A48DDE8A6B20A2A86EE8C3A375D4E195491850899E79EABB3BDE588772E20D26F15F622638E5DB192C40F18CBAF251FF8974D693002F0743FA150394599B8AFFCD1455CF60922730E3997970209E3867B6266413F68D84F52FDF37F5B8DFD1EF9C7927D0396D8E8D4FE1A387D9A1595675FB344C979AD2A8E8FE886137D65FC4FA17E0E8062D5F7510FE3AAC30F117CE0EB4B199AB4C37B5A72CFB8C1A93C1D62CD0414AC5BA368E679038FA9CA0B5E595E41B88A2ECA425A673F550B8BC70D7D6A25C8AAD0B5AC4F6C72F27FA36E7E821F76FF647A4403439A5800FEA53C145DAF2BE1BB7E62E08DF37B5F688155DC9086EB56991EEB53A12A82EDF0DE6A8BC721F51E682C0EC838AE11977733B5CC3ED8A45371C5606A4AD313A7FFF3FC6FC0FD987FF00692474F4C20D0000, '5.0.0.net45')