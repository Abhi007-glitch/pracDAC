
#Q1. finding file with extension .c and .pl

find / -type f -name "*.c" && find / -type f -name "*.pl"

#another Method 
# in this method -o acts as OR logical operator. 
# \(  \) - is use to group condtions together 
find / -type f \( -name "*.c" -o -name "*.pl" \) 

#Q2. Directory with permission 755 
find / -type f -perm 755


#Q3. Find files having inode number 12122
find -inum 12122

#Q4.Finding files havent accessed for more than a year 
find / -type f -atime +365

#Q5 Finding files having  size more than 1024kb 
find / -type f -size +1024k

#*********************************** EXTRA PRACT **************************************************************************************


#********************************************************** FIND AND EXECUTE  ********************************************************

# creating backup -> creates backup of all the .sh files with .backup extension 
# Command  ->     find . -type f -name "*.sh" -exec cp {} {}.backup  \;  
# \; acts as end of statement

#removing a set of files 
# command ->      find . -type f -name "*.backup" -exec rm {}  \;


