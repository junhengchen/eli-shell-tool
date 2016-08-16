#/bin/bash
#params=$@
#for [ i in ${param[@]} ]
#do
#done


if [ -f $1 ];
then
name=`echo $1|sed 's/.java//g'`
fi
#echo $name

result=" private static "$name" instance;\n public static "$name" getInstance()\{\n"
result=$result" if(instance==null)\{ instance=new "$name"();\n return instance;\} \n\}"
#echo $result 

printf "$result" | sed 's/\\//g' >> $1
