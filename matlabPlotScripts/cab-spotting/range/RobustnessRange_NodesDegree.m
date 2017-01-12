%  read labels and x-y data
load HighestDegreeTemporalRobustness.txt;     %  read data into the my_xy matrix
Prob = transpose(HighestDegreeTemporalRobustness(:,2));     %  copy first column of my_xy into x

load HighestDegreeTemporalRobustness.txt;     %  read data into the my_xy matrix
Err3 = transpose(HighestDegreeTemporalRobustness(:,3));     %  and second column into y

load HighestDegreeTemporalRobustness_Less.txt;     %  read data into the my_xy matrix
Err4 = transpose(HighestDegreeTemporalRobustness_Less(:,3));     %  and second column into y

xnodes = [Prob,fliplr(Prob)];
filled=[Err4,fliplr(Err3)];

hold on

fillhandle=fill(xnodes,filled,'g');
set(fillhandle,'EdgeColor','g','FaceAlpha',0.5,'EdgeAlpha',0.5);


xlabel('P_{attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');

grid on;
legend('robustness range');