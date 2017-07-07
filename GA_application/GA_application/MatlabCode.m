clear all clc;
close all;

feature=[12, 12, 10.5 ,0.01]
x=1:1:10;
for i=1:1:10
y(i)  = feature(1)*x(i) + 3* feature(2)*x(i)- 5* feature(3)*feature(4);           
end

plot(x,y)