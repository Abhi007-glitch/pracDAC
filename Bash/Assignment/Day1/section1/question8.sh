#! /bin/bash

# would receive file path from command line along with the command to execute bash file as argument

if [[ -e "$1" ]];
then
	echo "$(cat $1)"
else
	echo " Given File does not exits "
fi




