
# WORKING of GREP : grep searches for pattern line by line and print the line where it find the match 

# grep "abhi" temp.txt

# grep "abhi" temp.txt text.txt

# pattern matching irrespective of case of keyword
# grep -i "abhi" temp.txt 


# pattern matching with perfect word match only 
# grep -w "Abhi" temp.txt

#print line number where matching happens
# grep -n "abhi" temp.txt

#reads pattern from first file mention after -f and find all those words in rest of the mentioned files - most use full
# grep -f pattern.txt find1.txt find22.txt 


#return only the list of files name that have a matching word 
# grep -l "abhi" find.txt temp.txt text.txt

# pattern matching inside all the files in a directory
# grep -R "abhi" ./Bash


#return every thing execept given keyword
# grep -v "abhi" find.txt

#return count of matches 
# grep -c "abhi" find.txt

# searching for multiple keywords 
# grep -e "abhi" -e "pre" temp.txt 

# finding line starting with given keyword
# grep "^abhi" temp.txt

#finding lines ending with given keyword
#grep "abhi$" temp.txt



