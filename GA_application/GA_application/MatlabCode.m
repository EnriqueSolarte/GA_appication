clear all clc;
close all;

feature=[12, 12 ,0.01]
x=1:1:10;
for i=1:length(x)
y(i)  = feature(2)*sin(x(i)*3* feature(1)) + x(i)*x(i)*feature(3);           
end

plot(x,y, '*')
hold on 

new = [3.63 9.68 0.04];

for  i=1:length(x)
y2(i) =new(2)*sin(x(i)*3* new(1)) + x(i)*x(i)*new(3);          
end

plot(x,y2,'-')

