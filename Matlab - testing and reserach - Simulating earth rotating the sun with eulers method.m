
%%Simulating earth rotating the sun with eulers method.
%Constants and initialising vectors
 G=6.674*10^(-11); %gravitational constant
M=1.989e30; %Mass of sun
 m=5.927e24; %Mass of earth
h=1; %timestep

t=0:h:12;
%%t=[0:h:3.154e7];

distance=[];
speed=[];
angle=[];
angular_velocity=[];
x=[];
y=[];

%Initial conditions for speed
init_distance=1.496e11;
init_speed=0;

%Intial conditions for angle
init_angle=deg2rad(23.5);
init_angular_velocity=1.99e-7;

%% Settings first values
distance(1)=init_distance;
speed(1)=init_speed;
angle(1)=0;
angular_velocity(1)=init_angular_velocity;
dvdt=0;
dsdt=0;

x(1)=distance(1)*sin(angle(1));
y(1)=distance(1)*cos(angle(1));

%% Eulers Method
for i=2:length(t)  %eulers method
    dvdt=P(G,M,distance(i-1),angular_velocity(i-1));
    speed(i)=speed(i-1)+dvdt*h;
    distance(i)=distance(i-1)+speed(i)*h;
    
    dsdt=S(angular_velocity(i-1),speed(i-1),distance(i-1));
    
    angular_velocity(i)=angular_velocity(i-1)+dsdt*h;
    angle(i)=angle(i-1)+angular_velocity(i)*h;
    
    x(i)=distance(i)*sin(angle(i));
    y(i)=distance(i)*cos(angle(i));   
end

plot(0,0,'o','LineWidth',25,'markersize',5,'color','y'); %sun
hold on
plot(y,x);

function vel = P(Gravity,Mass,radius,ang_velocity)
vel=(radius*(ang_velocity^2) - (Gravity*Mass)/radius);
end

function angle= S(ang_velocity,velocity,radius)
angle=-((2*velocity*ang_velocity)/radius);
end

function vel = P(Gravity,Mass,radius,ang_velocity)
vel=(radius*(ang_velocity^2) - (Gravity*Mass)/radius);
end
function angle= S(ang_velocity,velocity,radius)
angle=-((2*velocity*ang_velocity)/radius);
end


%%https://www.mathworks.com/matlabcentral/answers/1607280-simulating-earth-rotating-the-sun-with-eulers-method