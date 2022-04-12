CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS contractors(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name TEXT NOT NULL
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS companies(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name TEXT NOT NULL
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS jobs(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  contractorId int,
  companyId int,
  FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
  FOREIGN KEY (companyId) REFERENCES companies(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
-- INSERT INTO
--   companies(name)
-- VALUES
--   ("contactors tinder")
INSERT INTO
  jobs(companyId, contractorId)
VALUES(3, 3)