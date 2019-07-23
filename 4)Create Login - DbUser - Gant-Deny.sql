USE [DocInfBase]
CREATE LOGIN DocInfBaseUser WITH PASSWORD='1q2w3e4r5'
CREATE USER DocInfBaseUser FOR LOGIN DocInfBaseUser WITH DEFAULT_SCHEMA=[dbo]
GRANT select TO DocInfBaseUser
GRANT update TO DocInfBaseUser
GRANT insert TO DocInfBaseUser
GRANT delete TO DocInfBaseUser
DENY UPDATE ON OBJECT::[Documents] ([Sum]) TO [DocInfBaseUser]