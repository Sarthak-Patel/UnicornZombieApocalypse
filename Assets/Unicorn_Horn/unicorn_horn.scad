// unicorn_horn.scad
//
// David Joy
// Created: 4/1/2011
// Last Updated: 5/20/2011
//
// A parametric Unicorn Horn design

// Calculate the current radius of the interior cone
function curr(rslope,max_rad,i) = max_rad - rslope*i;

// Generate a single slice of the horn
//
// zpos - The height of the slice
// radius - How big the internal radius is at this point
// step - Height of the step
// blob_rad - Radius of each blob
// angle - How far to twist the slice
// offset - Change the alignment of the slice (adds twistyness)
// node_ct - How many blobs to draw
module horn_slice(zpos,radius,step,blob_rad,angle,offset,node_ct){
  // Work out what angle to rotate the nodes through
  rot_slice = 360.0/node_ct; 

  translate([0,0,zpos]){
    rotate([0,0,angle]){
      union(){
        for(j=[0:node_ct-1]){
          color([0.5+0.5/node_ct*j,0.5,0.5+0.5/node_ct*j]) translate([0,offset/2,0]) rotate([0,0,rot_slice*j]) translate([radius,-offset,0]) sphere(blob_rad);
        }
      }
    }
  }
}

// Generate a horn, or part of a horn
//
// max_rad - Maximum radius of the cone
// min_rad - Minimum radius of the cone
// step - Height of the step
// height - Height of the horn
// full_twist - How many rotations to spiral through in deg (360 = 1 rotation)
// blob_min - Minimum size of the blobs
// blob_max - Maximum size of the blobs
// offset - How far off of center to make the horn
// seg_ct - Which segment to draw (< total_ct, 0 is the bottom, total_ct-1 is the top)
// total_ct - How many segments to split the horn into.  1 to draw the entire horn
// node_ct - How many blobs per slice.  4 is a good number
module horn(max_rad,min_rad,step,height,full_twist,blob_min,blob_max,offset,seg_ct,total_ct,node_ct)
{

  // Top and bottom clipping
  slice_t = max_rad; //How thick the clipping slice needs to be
  slice_r = max_rad*5; // How wide the clipping slice needs to be

  // Work out the slopes
  maxi = ceil(height/step);
  rslope = (max_rad - min_rad)/maxi;
  blob_slope = (blob_max - blob_min)/maxi;
  offset_slope = (offset)/maxi;
  twist = full_twist/maxi;
  
  // Work out the start and stop indices
  starti = floor(maxi/total_ct*seg_ct);
  stopi = floor(maxi/total_ct*(seg_ct + 1)+1);

  // Work out where the fill cone should go
  start_h = height/maxi*starti;
  stop_h = height/maxi*stopi;
  step_h = stop_h - start_h;
  difference(){
    union(){
      color([0,1,0]) translate([0,0,start_h]) cylinder(h=step_h,r1=curr(rslope,max_rad,starti),r2=curr(rslope,max_rad,stopi),center=false);
      for ( i=[starti:stopi] ){
        // Only generate the appropriate part of the horn
          horn_slice(i*step,curr(rslope,max_rad,i)-rslope,step,blob_max-i*blob_slope,twist*i,offset-i*offset_slope,node_ct);
      }
    }
  // Chop the top and the bottom
  translate([0,0,start_h-slice_t]) cylinder(h=slice_t,r=slice_r);
  translate([0,0,stop_h]) cylinder(h=slice_t,r=slice_r);

  }

}

// Parameters for printing
full_scale = 0.25;  // Scale parametric height to real height
layout = "full"; // full to see the layout, print to make it printable

// Parameters for geometry
height = 800*full_scale; // Parametric height

// Geometric controls
max_rad = 25*full_scale; // Maximum horn radius
min_rad = 1*full_scale; // Minimum horn radius
step = 10*full_scale; // Step size to increment
full_twist = 720*2; // Twist of horn in degrees
offset = 15*full_scale; // Distortion in horn
node_ct = 4; // Number of nodes to generate

// Size of the metaballs to use
blob_min= 8*full_scale; // Smallest they get
blob_max = 25*full_scale; // Biggest they get

// Print brace thickness, height
brace_t = 0.3; // mm
brace_h_ratio = 0.75; // Percent of the height to make the brace

if (layout == "full"){
// Constants to make the horn in one piece
assign(segments = 1,l0=0){
 horn(max_rad,min_rad,step,height,full_twist,blob_min,blob_max,offset,l0,segments,node_ct);
}
}

if ((layout == "print")){
// Constants for printing
  assign(segments = 4, spacing = 3,l0=0,l1=1,l2=2,l3=3){

// Draw the four horn slices
translate([-max_rad*spacing,max_rad*spacing,-height/segments*l0]) horn(max_rad,min_rad,step,height,full_twist,blob_min,blob_max,offset,l0,segments,node_ct);

translate([max_rad*spacing,max_rad*spacing,-height/segments*l1]) horn(max_rad,min_rad,step,height,full_twist,blob_min,blob_max,offset,l1,segments,node_ct);

translate([-max_rad*spacing,-max_rad*spacing,-height/segments*l2]) horn(max_rad,min_rad,step,height,full_twist,blob_min,blob_max,offset,l2,segments,node_ct);

translate([max_rad*spacing,-max_rad*spacing,-height/segments*l3]) horn(max_rad,min_rad,step,height,full_twist,blob_min,blob_max,offset,l3,segments,node_ct);

// Make bridges between all the parts
assign(brace_h = height/segments*brace_h_ratio){
  translate([-max_rad*spacing,-max_rad*spacing,0]) cube([brace_t,max_rad*spacing*2,brace_h]); 
  translate([-max_rad*spacing,-max_rad*spacing,0]) cube([max_rad*spacing*2,brace_t,brace_h]); 
  translate([-max_rad*spacing,max_rad*spacing,0]) cube([max_rad*spacing*2,brace_t,brace_h]); 
  translate([max_rad*spacing,-max_rad*spacing,0]) cube([brace_t,max_rad*spacing*2,brace_h]); 
}
}
}
