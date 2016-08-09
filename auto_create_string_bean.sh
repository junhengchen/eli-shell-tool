#!/bin/bash
# input a param to create a file!
# named by the param!

file_name=$1;

if [ $file_name ]

then

#echo $file_name
#touch $file_name

result_text=" public class "${file_name}" \{\n"
      
all_param=($@)

#1 make bean param
count=$[$#-1]
j=1
while [ $j -le $count ]
do
  bean_param[$j]=${all_param[$j]}
#echo ${all_param[$j]}
  ((j++))
done 
  #print test
  #echo after handled params ${bean_param[@]}


#2 append param define
for i in ${bean_param[@]}
do
result_text=$result_text" private String "$i";\n"
done

#echo result_text $result_text 

#test result
#echo $result_text

#3 append param get/set method
for i in ${bean_param[@]}
do
result_text=$result_text" public String get"$i"()\n\{\n return "$i"\}"

result_text=$result_text" public void set"$i"(String param)\n\{\n this."$i"=param\n\}"
done
result_text=$result_text"\n\}\n"

#4 create java file
printf "$result_text" | sed 's/\\//' > $file_name".java"
#echo $result_text

else

echo Please type file name!

fi

