%  read labels and x-y data
load ClosenessTemporalRibustness.txt;     %  read data into the my_xy matrix
Prob = transpose(ClosenessTemporalRibustness(:,2));     %  copy first column of my_xy into x
Err1 = transpose(ClosenessTemporalRibustness(:,3));     %  and second column into y

load ClosenessTemporalRibustness_Less.txt;     %  read data into the my_xy matrix
Err2 = transpose(ClosenessTemporalRibustness_Less(:,3));     %  and second column into y

xpoints=[Prob,fliplr(Prob)];
filled=[Err2,fliplr(Err1)];

hold on

fillhandle=fill(xpoints,filled,'b');
set(fillhandle,'EdgeColor','b','FaceAlpha',0.5,'EdgeAlpha',0.5);


xlabel('P_{attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');

grid on;
legend('robustness range');