%  read labels and x-y data
load ContactUpdatesRobustness.txt;     %  read data into the my_xy matrix
Prob = transpose(ContactUpdatesRobustness(:,2));     %  copy first column of my_xy into x

load ContactUpdatesRobustness.txt;     %  read data into the my_xy matrix
Err5 = transpose(ContactUpdatesRobustness(:,3));     %  and second column into y

load ContactUpdatesRobustness_Less.txt;     %  read data into the my_xy matrix
Err6 = transpose(ContactUpdatesRobustness_Less(:,3));     %  and second column into y

xpoints=[Prob,fliplr(Prob)];
filled=[Err6,fliplr(Err5)];

hold on

fillhandle=fill(xpoints,filled,'r');
set(fillhandle,'EdgeColor','r','FaceAlpha',0.5,'EdgeAlpha',0.5);


xlabel('P_{attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');

grid on;
legend('robustness range');

%title('Mean monthly precipitation at Portland International Airport');