clear all clc;
close all;

feature=[12, 12, 10.5 ,0.01]
x=1:1:10;
for i=1:1:10
y(i)  = feature(1)*x(i) + 3* feature(2)*x(i)*x(i)- 5* feature(3)*feature(4);           
end
y
plot(x,y, '*')
hold on 

new = [7.91 11.39 -0.02 13.06]

x=1:1:10;
for i=1:1:10
y2(i)  = new(1)*x(i) + 3* new(2)*x(i)*x(i)- 5* new(3)*new(4);           
end

plot(x,y2,'-')

